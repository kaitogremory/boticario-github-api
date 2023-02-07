using MongoDB.Driver;
using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Repositories;

namespace Boticario.Github.Infra.Repositories
{
    public class BoticarioRepository : IBoticarioRepository
    {
        protected readonly IMongoContext<RepositorioGithub> _context;

        public BoticarioRepository(IMongoContext<RepositorioGithub> context)
        {
            _context = context;
        }

        public IEnumerable<RepositorioGithub> ListarTodosOsRepositorios()
        {
            var list = _context.Collection.Find(null).ToList();
            return list;
        }
    }
}
