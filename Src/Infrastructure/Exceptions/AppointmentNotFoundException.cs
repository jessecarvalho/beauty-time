namespace Infrastructure.Exceptions;

public class AppointmentNotFoundException : Exception
{
    public AppointmentNotFoundException() : base() {}
    public AppointmentNotFoundException(string message) : base (message) {}
    public AppointmentNotFoundException(string message, Exception exception) : base(message, exception) {}
}