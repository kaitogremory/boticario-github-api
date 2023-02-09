using Boticario.Github.Domain.Entities.Base;

namespace Boticario.Github.Domain.Entities
{
    public class GithubLanguageRepo : EntityBase
    {
        public GithubLanguageRepo(GithubAPIResponse response)
        {
            Language = response.Items.First().Language;
            Repositories = new();
            response.Items.ToList().ForEach(repo => { Repositories.Add(new GithubRepo(repo)); });
        }
        public string Language { get; set; }
        public List<GithubRepo> Repositories { get; set; }        
    }
}
