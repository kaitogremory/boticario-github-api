using Boticario.Github.Notifications;

namespace Boticario.Github.API.ViewModel
{
    public class ErrorViewModel
    {
        public string? Message { get; set; }
        public string? ExceptionMessage { get; set; }
        public IList<Description>? Descriptions { get; set; }
        public ErrorViewModel(string? message)
        {
            Message = message;
            ExceptionMessage = null;
            Descriptions = null;
        }

        public ErrorViewModel(Exception? exception)
        {
            Message = null;
            ExceptionMessage = exception?.Message;
            Descriptions = null;
        }

        public ErrorViewModel(IList<Description>? descriptions)
        {
            Message = null;
            ExceptionMessage = null;
            Descriptions = descriptions;
        }

        public ErrorViewModel(string? message, IList<Description>? descriptions)
        {
            Message = message;
            Descriptions = descriptions;
            ExceptionMessage = null;
        }

        public ErrorViewModel(string? message, Exception? exception)
        {
            Message = message;
            ExceptionMessage = exception?.Message;
            Descriptions = null;
        }

        public ErrorViewModel(string? message, Exception? exception, IList<Description>? descriptions)
        {
            Message = message;
            ExceptionMessage = exception?.Message;
            Descriptions = descriptions;
        }
    }
}
