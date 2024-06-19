using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;

namespace DotNetTask.Repository;

public interface IProgramRepository
{
    Task<IEnumerable<ProgramListDTO>> GetAllProgramAsync();
    Task<ProgramForm> CreateProgramAsync(ProgramForm task);
    Task DeleteProgramAsync(string programId);
    Task<ProgramForm> GetProgramByIdAsync(string programId);
    Task<ProgramForm> UpdateProgramAsync(ProgramForm task);
}