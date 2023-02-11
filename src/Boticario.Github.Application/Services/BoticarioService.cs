using Boticario.Github.Application.Interfaces;
using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Repositories;
using Boticario.Github.Domain.Interfaces.Services;

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

        public List<GithubLanguageRepo> ListReposFromGithubAPI()
        {
            try
            {
                return _githubService.ListReposFromGithubAPI().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ClearCollection()
        {
            try
            {
                _boticarioRepository.ClearCollection();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertManyGithubModel(List<GithubLanguageRepo> languageReposList)
        {
            try
            {
                languageReposList.ForEach(languageRepo => _boticarioRepository.InsertManyGithubModel(languageRepo.Repositories));                
            }
            catch (Exception)
            {
                throw;
            }
        }
                
        public void UpdateListReposFromGithubAPI()
        {            
            try
            {
                List<GithubLanguageRepo> repositorieList = this.ListReposFromGithubAPI();
                this.ClearCollection();
                this.InsertManyGithubModel(repositorieList);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public List<GithubRepo> ListGithubReposFromDb()
        {
            try
            {
                return _boticarioRepository.ListGithubReposFromDb()
                    .OrderByDescending(x => x.StarsCount)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
