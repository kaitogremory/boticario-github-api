using Boticario.Github.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Domain.Entities
{
    public class RepositorioGithub : EntityBase
    {
        public RepositorioGithub(string name, string language, int stars)
        {
            Language = language;            
            Name = name;
            StarsCount= stars;
        }

        public string Name { get; private set; }
        public string Language { get; private set; }
        public int StarsCount { get; private set; }
    }
}
