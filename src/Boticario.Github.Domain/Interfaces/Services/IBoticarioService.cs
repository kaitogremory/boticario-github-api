using Boticario.Github.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Domain.Interfaces.Services
{
    public interface IBoticarioService
    {
        IEnumerable<GithubLanguageRepo> ListarTodosOsRepositorios();
    }
}
