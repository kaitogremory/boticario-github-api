namespace Boticario.Github.API
{
    public class ApiSettings
    {
        public Database Database { get; set; }
    }

    public class Database
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string CollectionName { get; set; }
    }
}
