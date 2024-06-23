namespace Infrastructure.Exceptions;

public class EmailNotFoundException : Exception
{
    public EmailNotFoundException() : base() {}
    public EmailNotFoundException(string message) : base(message) {}

    public EmailNotFoundException(string message, Exception exception) : base(message, exception){}
    
}