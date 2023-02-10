using Boticario.Github.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Notifications.Errors
{
    public abstract class ErrorDescription : IDescription
    {
        public string Message { get; private set; }
        public NotificationLevel Level { get; }
        public Exception Exception { get; private set; }

        protected ErrorDescription(string message, NotificationLevel level, params string[] args)
        {
            Level = level;
            Message = message;

            foreach (var i in args)
            {
                Message = Message.Replace("{" + i + "}", i);
            }
        }

        protected ErrorDescription(string message, NotificationLevel level, Exception exception, params string[] args)
        {
            Level = level;
            Message = message;
            Exception = exception;

            foreach (var i in args)
            {
                Message = Message.Replace("{" + i + "}", i);
            }
        }
    }
}
