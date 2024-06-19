using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace DotNetTask.Repository;

public class ApplicationRepository : IApplicationRepository
{
    private readonly Container _taskContainer;
    private readonly IConfiguration configuration;

    public ApplicationRepository(CosmosClient cosmosClient, IConfiguration configuration)
    {
        this.configuration = configuration;

        var databaseName = configuration["CosmosDbSetting:Database"];
        var taskContainerName = "Application";
        _taskContainer = cosmosClient.GetContainer(databaseName, taskContainerName);
    }

    public async Task<IEnumerable<ApplicationListDTO>> GetAllApplications()
    {
        var query = _taskContainer.GetItemLinqQueryable<Application>()
            .Select(x => new ApplicationListDTO(){PersonalInformation = x.PersonalInformation, Id = x.Id})
            .ToFeedIterator();

        var tasks = new List<ApplicationListDTO>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            tasks.AddRange(response);
        }

        return tasks;
    }

    public async Task<IEnumerable<ApplicationListDTO>> GetAllApplicationsByProgram(string programId)
    {
        var query = _taskContainer.GetItemLinqQueryable<Application>()
            .Where(x => x.ProgramId == programId)
            .Select(x => new ApplicationListDTO(){PersonalInformation = x.PersonalInformation,ProgramId = x.ProgramId, Id = x.Id})
            .ToFeedIterator();

        var tasks = new List<ApplicationListDTO>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            tasks.AddRange(response);
        }

        return tasks;
    }

    public async Task<Application> GetApplicationByIdAsync(string applicationId, string programId)
    {
        var query = _taskContainer.GetItemLinqQueryable<Application>()
            .Where(t => t.Id == applicationId && t.ProgramId == programId)
            .Take(1)
            .ToFeedIterator();

        var response = await query.ReadNextAsync();
        return response.FirstOrDefault();
    }

    public async Task<Application> CreateApplicationAsync(Application task)
    {
        var response = await _taskContainer.CreateItemAsync(task);
        return response.Resource;
    }

    public async Task DeleteApplicationAsync(string applicationId, string programId)
    {
        await _taskContainer.DeleteItemAsync<ProgramForm>(applicationId,new PartitionKey(programId));
    }

    public async Task<Application> UpdateApplicationAsync(Application task)
    {
        var response = await _taskContainer.ReplaceItemAsync(task, task.Id);
        return response.Resource;
    }
}