using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Domain.Interfaces.Entities.Base
{
    public interface IEntityBase
    {
        public Guid Id { get; }
    }
}
