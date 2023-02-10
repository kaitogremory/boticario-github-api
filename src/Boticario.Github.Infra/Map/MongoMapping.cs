using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Entities.Base;
using Boticario.Github.Notifications;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Infra.Map
{
    public class MongoMapping
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<EntityBase>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);                         
            });

            BsonClassMap.RegisterClassMap<GithubLanguageRepo>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<Notifiable>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.UnmapMember(m => m.Notes);
            });

            BsonClassMap.RegisterClassMap<Note>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.UnmapMember(m => m.Errors);
                map.UnmapMember(m => m.Warnings);
                map.UnmapMember(m => m.Informations);
            });
        }
    }
}
