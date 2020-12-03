using Concepts.Demo.API.ConfigOptions;
using Concepts.Demo.API.Dtos;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Concepts.Demo.API.Services
{
    public class AgeApi
    {
        private readonly string _ageApiBaseUrl;

        public AgeApi(IOptions<AgeApiOptions> options)
        {
            _ageApiBaseUrl = options.Value.BaseUrl;
        }

        public virtual async Task<int> GetAge(string name)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"{_ageApiBaseUrl}/?name={name}");
            var responseBody = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<AgeApiUserDto>(responseBody);

            return user.Age;
        }
    }
}