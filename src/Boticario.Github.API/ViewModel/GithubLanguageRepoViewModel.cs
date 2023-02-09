namespace Boticario.Github.API.ViewModel
{
    public class GithubLanguageRepoViewModel
    {
        public Guid Id { get; set; }
        public string Language { get; set; }
        public IEnumerable<GithubRepoViewModel> Repositories { get; set; }
    }
}
