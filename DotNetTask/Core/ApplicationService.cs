using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;
using DotNetTask.Repository;

namespace DotNetTask.Core;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationService(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;

    }

    public async Task<ResponseDTO<IEnumerable<ApplicationListDTO>>> GetAllApplications()
    {
        var applicationList = await _applicationRepository.GetAllApplications();
        if (!applicationList.Any())
            return new ResponseDTO<IEnumerable<ApplicationListDTO>>
                { StatusCode = StatusCodes.Status200OK, Message = "No applications has been submitted yet for all programs" };
        return new ResponseDTO<IEnumerable<ApplicationListDTO>>()
            { StatusCode = StatusCodes.Status200OK, Message = "Application list retrieved for all program", Data = applicationList };
    }

    public async Task<ResponseDTO<IEnumerable<ApplicationListDTO>>> GetAllApplicationsByProgram(string programId)
    {
        var applicationList = await _applicationRepository.GetAllApplicationsByProgram(programId);
        if (!applicationList.Any())
            return new ResponseDTO<IEnumerable<ApplicationListDTO>>
                { StatusCode = StatusCodes.Status200OK, Message = "No applications has been submitted yet for this program" };
        return new ResponseDTO<IEnumerable<ApplicationListDTO>>()
            { StatusCode = StatusCodes.Status200OK, Message = "Application list retrieved for this program", Data = applicationList };
    }

    public async Task<ResponseDTO<Application>> GetApplicationByIdAsync(string applicationId, string programId)
    {
        var application = await _applicationRepository.GetApplicationByIdAsync(applicationId,programId);
        if (application == null)
            return new ResponseDTO<Application>
                { StatusCode = StatusCodes.Status404NotFound, Message = "Application does not exist" };
        return new ResponseDTO<Application>()
            { StatusCode = StatusCodes.Status200OK, Message = "Application details retrieved", Data = application };
    }

    public async Task<ResponseDTO<Application>> CreateApplicationAsync(ApplicationDTO model)
    {
        Validation(model);
        var application = new Application()
        {
            Id = Guid.NewGuid().ToString(),
            ProgramId = model.ProgramId,
            PersonalInformation = model.PersonalInformation,
            AdditionalQuestions = model.AdditionalQuestions
        };
        var result = await _applicationRepository.CreateApplicationAsync(application);
        if (result==null)
            return new ResponseDTO<Application>
                { StatusCode = StatusCodes.Status500InternalServerError, Message = "Application could not be submitted, try again" };
        return new ResponseDTO<Application>()
            { StatusCode = StatusCodes.Status201Created, Message = "Application submitted successfully", Data = application };
    }

    public async Task<ResponseDTO<object>> DeleteApplicationAsync(string applicationId, string programId)
    {
        var checkIfExist = await _applicationRepository.GetApplicationByIdAsync(applicationId,programId);
        if (checkIfExist == null)
            return new ResponseDTO<object>
                { StatusCode = StatusCodes.Status404NotFound, Message = "Application does not exist" };
        await _applicationRepository.DeleteApplicationAsync(applicationId,programId);
        return new ResponseDTO<object>
            { StatusCode = StatusCodes.Status204NoContent, Message = "Application deleted successfully" };
    }

    public async Task<ResponseDTO<Application>> UpdateApplicationAsync(Application model)
    {
        if(model == null)
            return new ResponseDTO<Application>
                { StatusCode = StatusCodes.Status400BadRequest, Message = "Invalid request" };
        var checkIfExist = await _applicationRepository.GetApplicationByIdAsync(model.Id,model.ProgramId);
        if (checkIfExist == null)
            return new ResponseDTO<Application>
                { StatusCode = StatusCodes.Status404NotFound, Message = "Application does not exist" };
        await _applicationRepository.DeleteApplicationAsync(model.Id,model.ProgramId);
        return new ResponseDTO<Application>
            { StatusCode = StatusCodes.Status204NoContent, Message = "Application updated successfully" };
    }
    
    private void Validation(ApplicationDTO model)
    {
        var error = new List<string>();
        if (model.AdditionalQuestions.MultiChoices.Any())
        {
            foreach (var item in model.AdditionalQuestions.MultiChoices)
            {
                if (item.Answer.Count > item.MaxChoice)
                    error.Add("Maximum number of choice exceeded");
            
            } 
        }
        
    }
}