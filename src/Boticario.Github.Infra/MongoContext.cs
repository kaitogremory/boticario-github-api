using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Boticario.Github.Infra
{
    public class MongoContext<T> : DbContext, IMongoContext<T> where T : class
    {
        private readonly IMongoDatabase _db;
        private IMongoCollection<T> collection;
        public IMongoCollection<T> Collection { get => collection; set => collection = value; }

        public MongoContext(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(databaseName);
            Collection = _db.GetCollection<T>(collectionName);
        }
    }
}
