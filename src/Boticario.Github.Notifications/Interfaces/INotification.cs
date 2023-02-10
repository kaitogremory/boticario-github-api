using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Notifications.Interfaces
{
    public interface INotification
    {
        IList<IDescription> List { get; }
        bool HasNotifications { get; }

        bool Includes(IDescription error);
        void Add(IDescription error);
    }
}
