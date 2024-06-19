using DotNetTask.Core;
using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controller;
[Route("api/programForm")]
[ApiController]
public class ProgramFormController : ControllerBase
{
    private readonly IProgramService _programService;
    public ProgramFormController(IProgramService programService)
    {
        _programService = programService;
    }
    [HttpPost("CreateProgram")]
    public async Task<IActionResult> CreateProgram(ProgramFormDTO model)
    {
        var res = await _programService.CreateProgramAsync(model);
        return Ok(res);
    }
    [HttpGet("GetAllProgram")]
    public async Task<IActionResult> GetAllProgram()
    {
        var res = await _programService.GetAllProgramAsync();
        return Ok(res);
    }
    [HttpGet("GetProgram/{programId}")]
    public async Task<IActionResult> GetProgram(string programId)
    {
        var res = await _programService.GetProgramByIdAsync(programId);
        return Ok(res);
    }
    [HttpPut("UpdateProgram")]
    public async Task<IActionResult> UpdateProgram(ProgramForm model)
    {
        var res = await _programService.UpdateProgramAsync(model);
        return Ok(res);
    }
    [HttpDelete("DeleteProgram/{programId}")]
    public async Task<IActionResult> DeleteProgram(string programId)
    {
        await _programService.DeleteProgramAsync(programId);
        return Ok();
    }
}