using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;
using DotNetTask.Repository;

namespace DotNetTask.Core;

public class ProgramService: IProgramService
{
    private readonly IProgramRepository _programRepository;

    public ProgramService(IProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }

    public async Task<ResponseDTO<IEnumerable<ProgramListDTO>>> GetAllProgramAsync()
    {
        var programList = await _programRepository.GetAllProgramAsync();
        if (!programList.Any())
            return new ResponseDTO<IEnumerable<ProgramListDTO>>
                { StatusCode = StatusCodes.Status200OK, Message = "No programs has been added yet" };
        return new ResponseDTO<IEnumerable<ProgramListDTO>>()
            { StatusCode = StatusCodes.Status200OK, Message = "Program list retrieved", Data = programList };
    }

    public async Task<ResponseDTO<ProgramForm>> CreateProgramAsync(ProgramFormDTO model)
    {
        Validation(model);
        var application = new ProgramForm()
        {
            Id = Guid.NewGuid().ToString(),
            ProgramTitle = model.ProgramTitle,
            ProgramDescription = model.ProgramDescription,
            AdditionalQuestions = model.AdditionalQuestions
        };
        var result = await _programRepository.CreateProgramAsync(application);
        if (result==null)
            return new ResponseDTO<ProgramForm>
                { StatusCode = StatusCodes.Status500InternalServerError, Message = "Program could not be created, try again" };
        return new ResponseDTO<ProgramForm>()
            { StatusCode = StatusCodes.Status201Created, Message = "Program created successfully", Data = application };
    }

    public async Task<ResponseDTO<object>> DeleteProgramAsync(string programId)
    {
        var checkIfExist = await _programRepository.GetProgramByIdAsync(programId);
        if (checkIfExist == null)
            return new ResponseDTO<object>
                { StatusCode = StatusCodes.Status404NotFound, Message = "Program does not exist" };
        await _programRepository.DeleteProgramAsync(programId);
        return new ResponseDTO<object>
            { StatusCode = StatusCodes.Status204NoContent, Message = "Program deleted successfully" };
    }

    public async Task<ResponseDTO<ProgramForm>> GetProgramByIdAsync(string programId)
    {
        var program = await _programRepository.GetProgramByIdAsync(programId);
        if (program == null)
            return new ResponseDTO<ProgramForm>
                { StatusCode = StatusCodes.Status404NotFound, Message = "Program does not exist" };
        return new ResponseDTO<ProgramForm>()
            { StatusCode = StatusCodes.Status200OK, Message = "Program details retrieved", Data = program };
    }

    public async Task<ResponseDTO<ProgramForm>> UpdateProgramAsync(ProgramForm model)
    {
        var checkIfExist = await _programRepository.GetProgramByIdAsync(model.Id);
        if (checkIfExist == null)
            return new ResponseDTO<ProgramForm>
                { StatusCode = StatusCodes.Status404NotFound, Message = "Program does not exist" };
        await _programRepository.UpdateProgramAsync(model);
        return new ResponseDTO<ProgramForm>
            { StatusCode = StatusCodes.Status204NoContent, Message = "Program updated successfully" };
    }

    private void Validation(ProgramFormDTO model)
    {
        
    }
}