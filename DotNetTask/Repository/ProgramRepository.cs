using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace DotNetTask.Repository;

public class ProgramRepository : IProgramRepository
{
    private readonly Container _taskContainer;
    private readonly IConfiguration configuration;

    public ProgramRepository(CosmosClient cosmosClient, IConfiguration configuration)
    {
        this.configuration = configuration;

        var databaseName = configuration["CosmosDbSetting:Database"];
        var taskContainerName = "Program";
        _taskContainer = cosmosClient.GetContainer(databaseName, taskContainerName);
    }

    public async Task<IEnumerable<ProgramListDTO>> GetAllProgramAsync()
    {
        var query = _taskContainer.GetItemLinqQueryable<ProgramForm>()
            .Select(x => new ProgramListDTO(){ProgramTitle = x.ProgramTitle,ProgramDescription = x.ProgramDescription, Id = x.Id})
            .ToFeedIterator();

        var tasks = new List<ProgramListDTO>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            tasks.AddRange(response);
        }

        return tasks;
    }

    public async Task<ProgramForm> CreateProgramAsync(ProgramForm task)
    {
        var response = await _taskContainer.CreateItemAsync(task);
        return response.Resource;
    }

    public async Task DeleteProgramAsync(string programId)
    {
        await _taskContainer.DeleteItemAsync<ProgramForm>(programId,new PartitionKey(programId));
    }
    
    public async Task<ProgramForm> GetProgramByIdAsync(string programId)
    {
        var query = _taskContainer.GetItemLinqQueryable<ProgramForm>()
            .Where(t => t.Id == programId)
            .Take(1)
            .ToQueryDefinition();

        var sqlQuery = query.QueryText; // Retrieve the SQL query

        var response = await _taskContainer.GetItemQueryIterator<ProgramForm>(query).ReadNextAsync();
        return response.FirstOrDefault();
    }

    public async Task<ProgramForm> UpdateProgramAsync(ProgramForm task)
    {
        var response = await _taskContainer.ReplaceItemAsync(task, task.Id);
        return response.Resource;
    }
}