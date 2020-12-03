using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Concepts.Demo.API.Tests.IntegrationTests
{
    public class CallExternalApiControllerIntegrationTests
    {
        [Fact]
        public async Task Should_PredictAgeFromName()
        {
            // Arrange
            var customHttpClient = new WebApplicationFactory<Startup>().CreateClient();

            // Act
            var getResponse = await customHttpClient.GetAsync($"/api/predictAge?name=any");

            // Assert
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var getResponseBody = await getResponse.Content.ReadAsStringAsync();
            getResponseBody.Should().Be("Predicted age for any = 36");
        }
    }
}