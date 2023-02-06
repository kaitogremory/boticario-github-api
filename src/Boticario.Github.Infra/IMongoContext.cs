using MongoDB.Driver;

namespace Boticario.Github.Infra
{
    public interface IMongoContext<T> where T : class
    {
        public IMongoCollection<T> Collection { get; set; }
    }
}
