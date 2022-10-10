using Customers.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Moq;
using Customers.API.Models;
using Customers.UnitTests.Fixtures;

namespace Customers.UnitTests.Systems.Controllers;

public class TestUsersController
{
    // Unit Tests: test systems in isolation
    [Fact]
    public async Task GetOnSuccessReturnsStatusCode200()
    {
        // Set up the system under test
        // Could set up factory design pattern here to prevent code duplication
        var mockUserService = new Mock<IUsersService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers);

        var systemUnderTest = new UserController(mockUserService.Object);

        // Make something happen
        var result = (OkObjectResult)await systemUnderTest.Get();

        // Check output
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetOnSuccessInvokesUserServiceExactlyOnce()
    {
        // Set up the system under test
        var mockUserService = new Mock<IUsersService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var systemUnderTest = new UserController(mockUserService.Object);

        // Make something happen
        var result = systemUnderTest.Get();

        // Check output
        mockUserService.Verify(service => service.GetAllUsers(), Times.Once());
    }

    [Fact]
    public async Task GetOnSuccessReturnsListOfUsers()
    {
        // Set up the system under test
        var mockUserService = new Mock<IUsersService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers);

        var systemUnderTest = new UserController(mockUserService.Object);

        // Make something happen
        var result = await systemUnderTest.Get();

        // Check output
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task GetOnNoUsersFoundReturns404()
    {
        // Set up the system under test
        var mockUserService = new Mock<IUsersService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var systemUnderTest = new UserController(mockUserService.Object);

        // Make something happen
        var result = await systemUnderTest.Get();

        // Check output
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}