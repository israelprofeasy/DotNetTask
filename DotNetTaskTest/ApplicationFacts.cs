using AutoFixture;
using DotNetTask.Core;
using DotNetTask.Data.DTOs;
using DotNetTask.Data.Models;
using DotNetTask.Repository;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace DotNetTaskTest;

public class ApplicationFacts
{
        private IApplicationService applicationService;
    private readonly IFixture fixture;
    public ApplicationFacts()
    {
        fixture = new Fixture();
    }
    [Fact]
    public async void ShouldSubmitApplication()
    {
        // Arrange
        var applicationDto = fixture.Create<ApplicationDTO>();
        var application = fixture.Build<Application>().With(x => x.PersonalInformation, applicationDto.PersonalInformation)
            .With(x => x.AdditionalQuestions, applicationDto.AdditionalQuestions).Create();
        var applicationRepo = Substitute.For<IApplicationRepository>();
        applicationRepo.CreateApplicationAsync(Arg.Any<Application>()).Returns(application);
        applicationService = new ApplicationService(applicationRepo);
        
        //Act
        var response = await applicationService.CreateApplicationAsync(applicationDto);

        //Assert
        Assert.Equal(StatusCodes.Status201Created, response.StatusCode);

    }
}