namespace Infrastructure.Exceptions;

public class WorkingDayNotFoundException : Exception
{
    public WorkingDayNotFoundException()
    {
    }
    
    public WorkingDayNotFoundException(string message) : base(message)
    {
    }
    
    public WorkingDayNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}