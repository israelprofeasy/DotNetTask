using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;

namespace DotNetTask.Core;

public interface IApplicationService
{
    Task<ResponseDTO<IEnumerable<ApplicationListDTO>>> GetAllApplications();
    Task<ResponseDTO<IEnumerable<ApplicationListDTO>>> GetAllApplicationsByProgram(string programId);
    Task<ResponseDTO<Application>> GetApplicationByIdAsync(string applicationId, string programId);
    Task<ResponseDTO<Application>> CreateApplicationAsync(ApplicationDTO task);
    Task<ResponseDTO<object>> DeleteApplicationAsync(string applicationId, string programId);
    Task<ResponseDTO<Application>> UpdateApplicationAsync(Application task);
}