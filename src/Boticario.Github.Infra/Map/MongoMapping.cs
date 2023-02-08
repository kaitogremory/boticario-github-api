using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Entities.Base;
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
                map.UnmapMember(map => map.Id);                
            });

            BsonClassMap.RegisterClassMap<RepositorioGithub>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
            });            
        }
    }
}
