using MongoDB.Driver;
using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Repositories;

namespace Boticario.Github.Infra.Repositories
{
    public class BoticarioRepository : IBoticarioRepository
    {
        protected readonly IMongoContext<GithubRepo> _context;

        public BoticarioRepository(IMongoContext<GithubRepo> context)
        {
            _context = context;
        }                             

        public async void ClearCollection()
        {
            await _context.Collection.DeleteManyAsync(Builders<GithubRepo>.Filter.Empty);
        }        

        public async void InsertManyGithubModel(List<GithubRepo> modelList)
        {
            await _context.Collection.InsertManyAsync(modelList);
        }

        public List<GithubRepo> ListGithubReposFromDb()
        {
            var list = _context.Collection.Find(_ => true);

            return list.ToList();
        }

        public GithubRepo GetRepoDetailByName(string name)
        {
            var filter = Builders<GithubRepo>.Filter.Eq("Name", name);

            return _context.Collection.Find(filter).FirstOrDefault();               
        }
    }
}
