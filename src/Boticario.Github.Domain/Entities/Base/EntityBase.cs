using Boticario.Github.Domain.Interfaces.Entities.Base;
using Boticario.Github.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable, IEntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
