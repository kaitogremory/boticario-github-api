namespace Boticario.Github.API.ViewModel
{
    public class GithubRepoViewModel
    {
        public Guid Id { get; private set; }
        public string Language { get; private set; }
        public string Name { get; private set; }        
        public int StartsCount { get; private set; }
        public string Owner { get; private set; }
        public DateTime CreatedAt { get; private set;}
    }
}
