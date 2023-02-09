using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Repositories;
using Boticario.Github.Domain.Interfaces.Services;

namespace Boticario.Github.Domain.Services
{
    public class BoticarioService : IBoticarioService
    {
        private readonly IBoticarioRepository _boticarioRepository;

        public BoticarioService(IBoticarioRepository repository)
        {
            _boticarioRepository = repository;
        }

        public IEnumerable<GithubLanguageRepo> ListarTodosOsRepositorios()
        {
            return _boticarioRepository.ListarTodosOsRepositorios();
        }
    }
}
