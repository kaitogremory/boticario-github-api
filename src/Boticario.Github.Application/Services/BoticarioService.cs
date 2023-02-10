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
    public class BoticarioService : IBoticarioService
    {
        private readonly IBoticarioRepository _boticarioRepository;
        private readonly IGithubService _githubService;

        public BoticarioService(IBoticarioRepository repository, IGithubService githubService)
        {
            _boticarioRepository = repository;
            _githubService = githubService;
        }

        public IEnumerable<GithubLanguageRepo> ListarTodosOsRepositorios()
        {
            return _boticarioRepository.ListarTodosOsRepositorios();
        }

        public void UpdateListReposFromGithubAPI()
        {            
            try
            {
                List<GithubLanguageRepo> repositorieList = _githubService.ListReposFromGithubAPI().ToList();

                foreach (var _languageRepo in repositorieList)
                {
                    foreach (var _repo in _languageRepo.Repositories)
                    {

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
