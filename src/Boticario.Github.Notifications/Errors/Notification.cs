using Boticario.Github.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Notifications.Errors
{
    public abstract class Notification : INotification
    {
        public IList<IDescription> List { get; } = new List<IDescription>();

        public bool HasNotifications => List.Any();

        public void Add(IDescription error)
        {
            List.Add(error);
        }

        public bool Includes(IDescription error)
        {
            return List.Contains(error);
        }

        public override string ToString() => string.Join(" | ", this.List.Select(x => x.Message));
    }
}
