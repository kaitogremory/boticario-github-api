using Boticario.Github.Domain.Entities.Base;
using Boticario.Github.Notifications;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var x = new DateTime();
            Test(string.IsNullOrWhiteSpace(Name), new Description("Nome inválido", NotificationLevel.Critical));
            Test(string.IsNullOrWhiteSpace(FullName), new Description("Nome Completo inválido", NotificationLevel.Critical));
            Test(string.IsNullOrWhiteSpace(Description), new Description("Descrição inválida", NotificationLevel.Critical));
            Test(string.IsNullOrWhiteSpace(Language), new Description("Linguagem inválida", NotificationLevel.Critical));
            Test(string.IsNullOrWhiteSpace(Owner), new Description("Dono inválido", NotificationLevel.Critical));
            Test(StartsCount <= 0, new Description($"StartsCount {StartsCount} é inválido", NotificationLevel.Critical));
            Test(ForksCount <= 0, new Description($"ForksCount {ForksCount} é inválido", NotificationLevel.Critical));
            Test(CreatedAt == new DateTime(), new Description("Data de criação é inválida", NotificationLevel.Critical));
            Test(UpdatedAt == new DateTime() || CreatedAt > UpdatedAt, new Description("Data de atualização é inválida", NotificationLevel.Critical));            
        }
    }
}

