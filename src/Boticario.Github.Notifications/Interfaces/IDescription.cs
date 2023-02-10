using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Notifications.Interfaces
{
    public interface IDescription
    {
        string Message { get; }
        NotificationLevel Level { get; }
        Exception Exception { get; }
    }
}
