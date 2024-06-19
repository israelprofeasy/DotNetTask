using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;

namespace DotNetTask.Repository;

public interface IApplicationRepository
{
    Task<IEnumerable<ApplicationListDTO>> GetAllApplications();
    Task<IEnumerable<ApplicationListDTO>> GetAllApplicationsByProgram(string programId);
    Task<Application> GetApplicationByIdAsync(string applicationId, string programId);
    Task<Application> CreateApplicationAsync(Application task);
    Task DeleteApplicationAsync(string applicationId, string programId);
    Task<Application> UpdateApplicationAsync(Application task);
}