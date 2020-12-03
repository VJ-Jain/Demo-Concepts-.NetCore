# .NET C# Concepts Demo

This repo will demonstrate simple usage for various C#, .NET core & .NET 5 concepts.

Currently below use cases are available:

| # | Use case | Details | References\ Concepts\ Packages used |
| - | - | - | - |
| 1 | Call External API endpoint | `CallExternalApiController.cs` calls external public API `https://api.agify.io/?name=any` to predict the age of a person by passing a name. | `DependencyInjection`, `Newtonsoft.JSON`, `Deserialization`, `IOptions`, `HttpClient`, `Dto`, `Microsoft.Extensions.Options` |
| 2 | Integration tests for APIs | Use default`WebApplicationFactory` to run integration tests against our API Client. | `Microsoft.ASPNetCore.Mvc.Testing`, `FluentAssertions` |
| 3 | Mocking services for unit tests | Use mocked response for external services and just test small unit. | `Moq`, `FluentAssertions`, `Mock Setup`, `Mock Verify`, `Microsoft.Extensions.Options` |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |

