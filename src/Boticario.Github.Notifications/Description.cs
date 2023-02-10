using Boticario.Github.Notifications.Errors;

namespace Boticario.Github.Notifications
{    
    public class Description : ErrorDescription
    {
        public Description(string message, NotificationLevel level, params string[] args) : base(message, level, args)
        {
        }

        public Description(string message, NotificationLevel level, Exception exception, params string[] args) : base(message, level, exception, args)
        {
        }
    }    
}