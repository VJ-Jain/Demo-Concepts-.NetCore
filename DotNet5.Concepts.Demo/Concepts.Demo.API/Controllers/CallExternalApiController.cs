using Concepts.Demo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Concepts.Demo.API.Controllers
{
    [ApiController]
    [Route("/api/predictAge")]
    public class CallExternalApiController : ControllerBase
    {
        private readonly AgeApi _ageApi;

        public CallExternalApiController(AgeApi ageApi)
        {
            _ageApi = ageApi;
        }

        [HttpGet]
        public async Task<ActionResult<string>> PredictAgeFromName([FromQuery] string name)
        {
            var age = await _ageApi.GetAge(name);

            return Ok($"Predicted age for {name} = {age}");
        }
    }
}