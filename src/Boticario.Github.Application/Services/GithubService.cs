using Boticario.Github.Application.Interfaces;
using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Repositories;
using Boticario.Github.Domain.Interfaces.Services;
using Boticario.Github.Domain.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Application.Services
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

        public IEnumerable<GithubAPIResponse> ListReposFromGithubAPI()
        {
            var result = new List<GithubAPIResponse>();

            string searchQuery = _config.GetSection("GithubSettings").GetSection("searchQuery").Value;
            string searchQueryConditions = _config.GetSection("GithubSettings").GetSection("searchQueryConditions").Value;
            string concatedlanguageList = _config.GetSection("GithubSettings").GetSection("languageList").Value;

            List<string> languageList = concatedlanguageList.Split(",").ToList();

            foreach (string language in languageList)
            {
                string url = string.Format("{0}{1}{2}", searchQuery, language, searchQueryConditions);
                result.Add(_httpRestService.Get(url).Result);
            }
            
            return result;
        }
    }
}
