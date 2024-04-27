namespace Infrastructure.Exceptions;

public class EstablishmentSocialMediaNotFoundException : Exception
{
    public EstablishmentSocialMediaNotFoundException() : base(){}
    public EstablishmentSocialMediaNotFoundException(string message) : base(message){}
    public EstablishmentSocialMediaNotFoundException(string message, Exception exception) : base(message, exception){}
}