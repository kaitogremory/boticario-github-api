using Boticario.Github.Domain.Entities.Base;
using Boticario.Github.Notifications;
using System.Drawing;

namespace Boticario.Github.Domain.Entities
{
    public class GithubLanguageRepo : EntityBase
    {
        public GithubLanguageRepo(GithubAPIResponse response, string language)
        {
            Language = language;
            Repositories = new();
            response.Items.ToList().ForEach(repo => { Repositories.Add(new GithubRepo(repo)); });

            Validate();
        }
        public string Language { get; set; }
        public List<GithubRepo> Repositories { get; set; }

        public override void Validate()
        {
            Notes.Clear();
            
            Test(string.IsNullOrWhiteSpace(Language), new Description("Language is invalid", NotificationLevel.Critical));
            Test(Repositories.Any(x => !x.IsValid()), new Description("Repositorie is invalid", NotificationLevel.Critical));            
        }
    }    
}
