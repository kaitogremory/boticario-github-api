using Boticario.Github.Domain.Entities.Base;
using Boticario.Github.Notifications;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Boticario.Github.Domain.Entities
{
    public class GithubRepo : EntityBase
    {
        public GithubRepo(Item responseItem)
        {
            Language = responseItem.Language;
            Name = responseItem.Name;
            FullName = responseItem.FullName;
            Description= responseItem.Description;
            Owner = responseItem.Owner.Login;
            StartsCount = (int)responseItem.StargazersCount;
            ForksCount = (int)responseItem.ForksCount;
            CreatedAt = responseItem.CreatedAt.DateTime;
            UpdatedAt = responseItem.UpdatedAt.DateTime;
        }        
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public string Description { get; private set; }
        public string Language { get; private set; }
        public string Owner { get; private set; }
        public int StartsCount { get; private set; }
        public int ForksCount { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public override void Validate()
        {
            Notes.Clear();
            
            Test(string.IsNullOrWhiteSpace(Name), new Description("Name is invalid", NotificationLevel.Critical));
            Test(string.IsNullOrWhiteSpace(FullName), new Description("FullName is invalid", NotificationLevel.Critical));
            Test(string.IsNullOrWhiteSpace(Description), new Description("Description is invalid", NotificationLevel.Critical));
            Test(string.IsNullOrWhiteSpace(Language), new Description("Language is invalid", NotificationLevel.Critical));
            Test(string.IsNullOrWhiteSpace(Owner), new Description("Owner is invalid", NotificationLevel.Critical));
            Test(StartsCount <= 0, new Description($"StartsCount {StartsCount} is invalid", NotificationLevel.Critical));
            Test(ForksCount <= 0, new Description($"ForksCount {ForksCount} is invalid", NotificationLevel.Critical));
            Test(CreatedAt == new DateTime(), new Description("CreatedAt is invalid", NotificationLevel.Critical));
            Test(UpdatedAt == new DateTime() || CreatedAt > UpdatedAt, new Description("UpdatededAt is invalid", NotificationLevel.Critical));            
        }
    }
}

