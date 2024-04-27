namespace Infrastructure.Exceptions;

public class EstablishmentNotFoundException : Exception
{
    public EstablishmentNotFoundException() : base() {}
    public EstablishmentNotFoundException(string message) : base (message) {}
    public EstablishmentNotFoundException(string message, Exception exception) : base(message, exception) {}
}