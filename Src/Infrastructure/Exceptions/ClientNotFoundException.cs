namespace Infrastructure.Exceptions;

public class ClientNotFoundException : Exception
{
    public ClientNotFoundException() : base() {}
    public ClientNotFoundException(string message) : base(message) {}
    public ClientNotFoundException(string message, Exception exception) : base(message, exception) {}
}