namespace Infrastructure.Exceptions;

public class EstablishmentAlreadyExistsException: Exception
{
    public EstablishmentAlreadyExistsException() : base() {}
    public EstablishmentAlreadyExistsException(string message) : base(message) {}

    public EstablishmentAlreadyExistsException(string message, Exception exception) : base(message, exception){}
    
}