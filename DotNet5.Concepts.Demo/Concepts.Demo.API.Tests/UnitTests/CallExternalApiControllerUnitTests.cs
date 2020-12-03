using Concepts.Demo.API.ConfigOptions;
using Concepts.Demo.API.Controllers;
using Concepts.Demo.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Concepts.Demo.API.Tests.UnitTests
{
    public class CallExternalApiControllerUnitTests
    {
        [Fact]
        public async Task Should_PredictAgeFromName()
        {
            // Arrange
            var options = Options.Create(new AgeApiOptions { BaseUrl = "anyBaseUrl" });
            var mockAgeApi = new Mock<AgeApi>(options);
            mockAgeApi.Setup(_ => _.GetAge(It.IsAny<string>())).ReturnsAsync(25);

            var externalApiController = new CallExternalApiController(mockAgeApi.Object);

            // Act
            var response = (await externalApiController.PredictAgeFromName("any")).Result as OkObjectResult;

            // Assert
            response.Value.Should().Be("Predicted age for any = 25");
            mockAgeApi.Verify(_ => _.GetAge(It.IsAny<string>()), Times.Once);
        }
    }
}