namespace Infrastructure.Exceptions;

public class EstablishmentAlreadyDisabledException : Exception
{
    public EstablishmentAlreadyDisabledException(string message) : base(message)
    {
    }
    
    public EstablishmentAlreadyDisabledException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
    public EstablishmentAlreadyDisabledException()
    {
    }
    
}