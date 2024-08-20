namespace Infrastructure.Exceptions;

public class ServiceAlreadyExistsException : Exception
{
    public ServiceAlreadyExistsException(string message) : base(message)
    {
    }
    
    public ServiceAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
    public ServiceAlreadyExistsException()
    {
    }
}