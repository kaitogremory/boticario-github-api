using AutoMapper;
using Boticario.Github.API.ViewModel;
using Boticario.Github.Domain.Entities;

namespace Boticario.Github.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GithubLanguageRepo, GithubLanguageRepoViewModel>();
            CreateMap<GithubRepo, GithubRepoViewModel>();
        }
    }
}
