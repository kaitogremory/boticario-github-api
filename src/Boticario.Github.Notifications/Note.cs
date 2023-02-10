using Boticario.Github.Notifications.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Notifications
{
    public partial class Note : Notification
    {
        public IList<Description> Errors => List.Cast<Description>().Where(x => x.Level is NotificationLevel.Critical).ToList();
        public IList<Description> Warnings => List.Cast<Description>().Where(x => x.Level is NotificationLevel.Warning).ToList();
        public IList<Description> Informations => List.Cast<Description>().Where(x => x.Level is NotificationLevel.Information).ToList();
        public bool HasErrors => List.Cast<Description>().Any(x => x.Level is NotificationLevel.Critical);
        public bool HasWarnings => List.Cast<Description>().Any(x => x.Level is NotificationLevel.Warning);
        public bool HasInformations => List.Cast<Description>().Any(x => x.Level is NotificationLevel.Information);

        public void Clear()
        {
            List.Clear();
        }
    }
}
