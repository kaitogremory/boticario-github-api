namespace Boticario.Github.API.ViewModel
{
    public class ErrorViewModel
    {
        public string? Message { get; set; }
        public string? ExceptionMessage { get; set; }        
        public ErrorViewModel(string? message)
        {
            Message = message;
            ExceptionMessage = null;            
        }

        public ErrorViewModel(Exception? exception)
        {
            Message = null;
            ExceptionMessage = exception?.Message;            
        }       
        
        public ErrorViewModel(string? message, Exception? exception)
        {
            Message = message;
            ExceptionMessage = exception?.Message;
        }        
    }
}
