using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;

namespace DotNetTask.Core;

public interface IProgramService
{
    Task<ResponseDTO<IEnumerable<ProgramListDTO>>> GetAllProgramAsync();
    Task<ResponseDTO<ProgramForm>> CreateProgramAsync(ProgramFormDTO task);
    Task<ResponseDTO<object>> DeleteProgramAsync(string programId);
    Task<ResponseDTO<ProgramForm>> GetProgramByIdAsync(string programId);
    Task<ResponseDTO<ProgramForm>> UpdateProgramAsync(ProgramForm task);
}