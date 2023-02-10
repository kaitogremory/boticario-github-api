using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Repositories;
using Boticario.Github.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Boticario.Github.Domain.Services
{
    public class GithubService : IGithubService
    {
        private readonly IHttpRestService _httpRestService;
        private readonly IConfiguration _config;

        public GithubService(IHttpRestService service, IConfiguration config)
        {
            _config = config;
            _httpRestService = service;
        }

        public IEnumerable<GithubLanguageRepo> ListReposFromGithubAPI()
        {
            var resultList = new List<GithubLanguageRepo>();

            string searchQuery = _config.GetSection("GithubSettings").GetSection("searchQuery").Value;
            string searchQueryConditions = _config.GetSection("GithubSettings").GetSection("searchQueryConditions").Value;
            string concatedlanguageList = _config.GetSection("GithubSettings").GetSection("languageList").Value;

            List<string> languageList = concatedlanguageList.Split(",").ToList();

            foreach (string language in languageList)
            {                
                var result = _httpRestService.GetByUrl(string.Format("{0}{1}{2}", searchQuery, language, searchQueryConditions)).Result;
                GithubAPIResponse response = JsonConvert.DeserializeObject<GithubAPIResponse>(result);

                resultList.Add(new GithubLanguageRepo(response, language));
            }

            return resultList;
        }
    }
}
