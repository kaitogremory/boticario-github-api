using Boticario.Github.Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Domain.Entities.Base
{
    public abstract class EntityBase : IEntityBase
    {
        protected EntityBase()
        {
            BaseId = Guid.NewGuid();
        }

        public Guid BaseId { get; }
    }
}
