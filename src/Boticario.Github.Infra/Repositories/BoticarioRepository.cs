using MongoDB.Driver;
using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Repositories;

namespace Boticario.Github.Infra.Repositories
{
    public class BoticarioRepository : IBoticarioRepository
    {
        protected readonly IMongoContext<GithubLanguageRepo> _context;

        public BoticarioRepository(IMongoContext<GithubLanguageRepo> context)
        {
            _context = context;
        }

        public IEnumerable<GithubLanguageRepo> ListarTodosOsRepositorios()
        {
            var list = _context.Collection.Find(_ => true);

            var results = list.ToList();

            return results;
        }
    }
}
