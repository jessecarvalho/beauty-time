namespace Infrastructure.Exceptions;

public class ServiceNotFoundException : Exception
{
    public ServiceNotFoundException() : base() {}
    public ServiceNotFoundException(string message) : base(message) {}
    public ServiceNotFoundException(string message, Exception exception) : base(message, exception) {}
}