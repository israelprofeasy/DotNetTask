using AutoFixture;
using DotNetTask.Core;
using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;
using DotNetTask.Repository;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace DotNetTaskTest;

public class ProgramFacts
{
    private IProgramService programService;
    private readonly IFixture fixture;
    public ProgramFacts()
    {
        fixture = new Fixture();
    }
    [Fact]
    public async void ShouldCreateProgram()
    {
        // Arrange
        var programDto = fixture.Create<ProgramFormDTO>();
        var programForm = fixture.Build<ProgramForm>().With(x => x.ProgramDescription, programDto.ProgramTitle)
            .With(x => x.ProgramDescription, programDto.ProgramDescription)
            .With(x => x.AdditionalQuestions, programDto.AdditionalQuestions).Create();
        var programRepo = Substitute.For<IProgramRepository>();
        programRepo.CreateProgramAsync(Arg.Any<ProgramForm>()).Returns(programForm);
        programService = new ProgramService(programRepo);
        
        //Act
        var response = await programService.CreateProgramAsync(programDto);

        //Assert
        Assert.Equal(StatusCodes.Status201Created, response.StatusCode);

    }
    [Fact]
    public async void ShouldDeleteProgram()
    {
        // Arrange
        var program = fixture.Create<ProgramForm>();
        var programRepo = Substitute.For<IProgramRepository>();
        programRepo.GetProgramByIdAsync(program.Id).Returns(program);
        //programRepo.DeleteProgramAsync(programForm.Id).Returns(programForm);
        programService = new ProgramService(programRepo);
        
        //Act
        var response = await programService.DeleteProgramAsync(program.Id);

        //Assert
        Assert.Equal(StatusCodes.Status204NoContent, response.StatusCode);

    }
    
    [Fact]
    public async void ShouldUpdateProgram()
    {
        // Arrange
        var programOld = fixture.Create<ProgramForm>();
        var programNew = fixture.Build<ProgramForm>().With(x => x.Id, programOld.Id).Create();
        var programRepo = Substitute.For<IProgramRepository>();
        programRepo.GetProgramByIdAsync(programNew.Id).Returns(programOld);
        //programRepo.DeleteProgramAsync(programForm.Id).Returns(programForm);
        programService = new ProgramService(programRepo);
        
        //Act
        var response = await programService.UpdateProgramAsync(programNew);

        //Assert
        Assert.Equal(StatusCodes.Status204NoContent, response.StatusCode);

    }
    
    [Fact]
    public async void ShouldGetProgram()
    {
        // Arrange
        var program = fixture.Create<ProgramForm>();
        var programRepo = Substitute.For<IProgramRepository>();
        programRepo.GetProgramByIdAsync(program.Id).Returns(program);
        programService = new ProgramService(programRepo);
        
        //Act
        var response = await programService.GetProgramByIdAsync(program.Id);

        //Assert
        Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
        Assert.Equal(program.Id, response.Data.Id);

    }
}