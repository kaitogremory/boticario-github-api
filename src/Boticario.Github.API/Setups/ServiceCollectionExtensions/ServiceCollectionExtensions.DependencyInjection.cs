using AutoMapper;
using Boticario.Github.API.Mappings;
using Boticario.Github.API.Settings;
using Boticario.Github.Application.Interfaces;
using Boticario.Github.Application.Services;
using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Repositories;
using Boticario.Github.Domain.Interfaces.Services;
using Boticario.Github.Domain.Services;
using Boticario.Github.Infra;
using Boticario.Github.Infra.Map;
using Boticario.Github.Infra.Repositories;
using Microsoft.AspNetCore.Http.Json;

namespace Boticario.Github.API.Setups.ServiceCollectionExtensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            var options = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();

            #region Services

            builder.Services.AddScoped<IBoticarioService, BoticarioService>();
            builder.Services.AddScoped<IHttpRestService, HttpRestService>();
            builder.Services.AddScoped<IGithubService, GithubService>();

            #endregion

            #region Mapping

            MongoMapping.Configure();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);

            #endregion

            #region JsonOptions

            builder.Services.Configure<JsonOptions>(o => { o.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull; });

            #endregion

            #region Repositories

            builder.Services.AddScoped<IBoticarioRepository, BoticarioRepository>();
            builder.Services.AddScoped<IMongoContext<GithubLanguageRepo>>(option => new MongoContext<GithubLanguageRepo>(options.Database.ConnectionString, options.Database.Name, options.Database.CollectionName));

            #endregion

            return builder;
        }
    }
}
