using Boticario.Github.Domain.Entities;

namespace Boticario.Github.Domain.Interfaces.Services
{
    public interface IGithubService
    {
        IEnumerable<GithubLanguageRepo> ListReposFromGithubAPI();
    }
}
