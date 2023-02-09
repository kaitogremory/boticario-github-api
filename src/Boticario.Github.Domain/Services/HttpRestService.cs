using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace Boticario.Github.Domain.Services
{
    public class HttpRestService : IHttpRestService
    {        
        private readonly IConfiguration _config;
        private string _baseUrl;
        private string _token;

        public HttpRestService(IConfiguration config)
        {
            _config = config;
            _baseUrl = GetBaseUrl();
            _token = TokenToBase64();
        }

        public async Task<GithubAPIResponse> Get(string url)
        {            
            GithubAPIResponse? result = null;

            using (HttpClient client = new HttpClient { BaseAddress = new Uri(_baseUrl) })
            {
                client.DefaultRequestHeaders.Add("User-Agent", "BotiGitHubTest2");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _token);

                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    response.EnsureSuccessStatusCode();
                    var responseStr = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GithubAPIResponse>(responseStr);
                    result.Language = result.Items.First().Language;
                }                
            }

            return result;
        }

        public string TokenToBase64()
        {
            return Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                    string.Format("{0}:{1}", "", _config.GetSection(
                    "GithubSettings").GetSection("token").Value)));
        }

        public string GetBaseUrl() => _config.GetSection("GithubSettings").GetSection("baseUrl").Value;
    }
}
