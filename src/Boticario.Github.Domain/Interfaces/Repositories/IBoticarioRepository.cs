using Boticario.Github.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Domain.Interfaces.Repositories
{
    public interface IBoticarioRepository
    {
        IEnumerable<GithubLanguageRepo> ListarTodosOsRepositorios();
    }
}
