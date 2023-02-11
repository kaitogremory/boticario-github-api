using Boticario.Github.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

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

        public async Task<string> GetByUrl(string url)
        {
            string result;

            using (HttpClient client = new HttpClient { BaseAddress = new Uri(_baseUrl) })
            {
                client.DefaultRequestHeaders.Add("User-Agent", "BotiGitHubTest");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _token);

                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    response.EnsureSuccessStatusCode();
                    result = await response.Content.ReadAsStringAsync();                    
                }                
            }

            return result;
        }

        public string TokenToBase64()
        {
            string token = string.Format("{0}{1}", 
                _config.GetSection("GithubSettings").GetSection("tokenFirstPart").Value,
                _config.GetSection("GithubSettings").GetSection("tokenSecondPart").Value);
                
            string base64Token = Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                    string.Format("{0}:{1}", String.Empty, token)));

            return base64Token;
        }

        public string GetBaseUrl() => _config.GetSection("GithubSettings").GetSection("baseUrl").Value;
    }
}
