using Boticario.Github.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Application.Interfaces
{
    public interface IGithubService
    {
        IEnumerable<GithubAPIResponse> ListReposFromGithubAPI();
    }
}
