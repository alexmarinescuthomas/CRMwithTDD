using Customers.API.Models;
using Customers.UnitTests.Fixtures;
using Customers.UnitTests.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Net;

namespace Customers.UnitTests.Systems.Services
{
    public class TestUserService
    {
        // Unit test the services, e.g. HTTP request
        [Fact]
        public async Task GetAllUsersWhenCalledInvokesHttpGet()
        {
            // Set up the system under test
            var expectedResponse = UsersFixture.GetTestUsers();
            var handleMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handleMock.Object);
            var systemUnderTest = new UsersService(httpClient);

            // Make something happen
            await systemUnderTest.GetAllUsers();

            // Check output and ensure HTTP request is made
            handleMock
                .Protected()
                .Verify(
                    "SendAsync", 
                    Times.Exactly(1), 
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async Task ReturnsEmptyListOn404Message()
        {
            // Set up the system under test
            var handleMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handleMock.Object);
            var systemUnderTest = new UsersService(httpClient);

            // Make something happen
            var result = await systemUnderTest.GetAllUsers();

            // Check output and ensure HTTP request is made
            result.Count.Should().Be(0);
        }

        [Fact]
        public async Task ReturnsListOfExpectedSize()
        {
            // Set up the system under test 
            var expectedResponse = UsersFixture.GetTestUsers();
            var handleMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handleMock.Object);
            var systemUnderTest = new UsersService(httpClient);

            // Make something happen
            var result = await systemUnderTest.GetAllUsers();

            // Check output and ensure HTTP request is made
            result.Count.Should().Be(expectedResponse.Count);
        }
    }
}