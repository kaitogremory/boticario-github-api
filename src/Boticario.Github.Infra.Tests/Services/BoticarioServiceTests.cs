using Boticario.Github.Application.Interfaces;
using Boticario.Github.Application.Services;
using Boticario.Github.Domain.Entities;
using Boticario.Github.Domain.Interfaces.Repositories;
using Boticario.Github.Domain.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Boticario.Github.Infra.Tests.Services
{
    [TestClass()]
    public class BoticarioServiceTests
    {
        protected Mock<IBoticarioRepository> mockBoticarioRepository;
        protected Mock<IGithubService> mockGithubService;
        protected GithubLanguageRepo validGithubLanguageRepo;
        protected GithubAPIResponse validGithubApiResponse;

        BoticarioServiceTests() 
        {
            mockBoticarioRepository = new Mock<IBoticarioRepository>();
            mockGithubService= new Mock<IGithubService>();

            validGithubApiResponse = new GithubAPIResponse()
            {
                
            };
            validGithubLanguageRepo = new GithubLanguageRepo(validGithubApiResponse, "Linguagem Teste");
            
            
        }

        [TestMethod]
        public void ListReposFromGithubAPIWithSuccess()
        {
            mockGithubService
                .Setup(s => s.ListReposFromGithubAPI())
                .Returns(new List<GithubLanguageRepo>() { validGithubLanguageRepo });

            var boticarioService = new BoticarioService(mockBoticarioRepository.Object, mockGithubService.Object);
            var repoList = boticarioService.ListReposFromGithubAPI();
            var firstRepo = repoList.FirstOrDefault();

            Assert.IsNotNull(repoList);
            Assert.IsInstanceOfType(repoList, typeof(ICollection<GithubLanguageRepo>));
            Assert.IsTrue(firstRepo.IsValid());
        }
    }
}