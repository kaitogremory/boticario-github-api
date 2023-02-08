using Boticario.Github.Application.Interfaces;
using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Repositories;
using Boticario.Github.Domain.Interfaces.Services;
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

        public GithubService(IHttpRestService service) 
        { 
            _httpRestService= service;
        }

        public RepositorioGithub ListarTodosOsRepositorios()
        {
            var result = _httpRestService.Get();

            return new RepositorioGithub("", "", 2);
        }
    }
}
