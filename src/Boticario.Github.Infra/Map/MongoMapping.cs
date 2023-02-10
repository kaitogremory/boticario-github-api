using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Entities.Base;
using Boticario.Github.Notifications;
using MongoDB.Bson.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace Boticario.Github.Infra.Map
{
    [ExcludeFromCodeCoverage]
    public class MongoMapping
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<EntityBase>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(map => map.Id);
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
