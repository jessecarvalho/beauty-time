namespace Infrastructure.Exceptions;

public class EstablishmentAlreadyEnabledException : Exception
{
    public EstablishmentAlreadyEnabledException(string message) : base(message)
    {
    }
    
    public EstablishmentAlreadyEnabledException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
    public EstablishmentAlreadyEnabledException()
    {
    }
    
}