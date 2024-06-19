using DotNetTask.Core;
using DotNetTask.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controller;

[Route("api/application")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public ApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;

    }
    [HttpPost("SubmitApplication")]
    public async Task<IActionResult> SubmitApplication(ApplicationDTO model)
    {
        var res = await _applicationService.CreateApplicationAsync(model);
        return Ok(res);
    }
    
    [HttpGet("GetApplication/{programId}/{applicationId}")]
    public async Task<IActionResult> GetApplication(string applicationId, string programId)
    {
        var res = await _applicationService.GetApplicationByIdAsync(applicationId, programId);
        return Ok(res);
    }
    
    [HttpGet("GetProgramApplication/{programId}")]
    public async Task<IActionResult> GetProgramApplication(string programId)
    {
        var res = await _applicationService.GetAllApplicationsByProgram(programId);
        return Ok(res);
    }
    
    [HttpDelete("DeleteProgram/{applicationId}")]
    public async Task<IActionResult> DeleteProgram(string applicationId, string programId)
    {
        var res = await _applicationService.DeleteApplicationAsync(applicationId,programId);
        return Ok(res);
    }
}