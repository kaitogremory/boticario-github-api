using Boticario.Github.Domain.Entities.Base;
using System;
using System.Collections.Generic;
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
        


    }
}
