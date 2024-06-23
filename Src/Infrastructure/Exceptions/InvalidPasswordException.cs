namespace Infrastructure.Exceptions;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base() {}
    public InvalidPasswordException(string message) : base(message) {}

    public InvalidPasswordException(string message, Exception exception) : base(message, exception){}
}