namespace Core.Entities;

public class WorkingDay
{
    public int Id { get; set; }
    public int Day { get; set; }
    public string StartHour { get; set; }
    public string EndHour { get; set; }
    public int EstablishmentId { get; set; }
    public int UserId { get; set; }
    
    public WorkingDay(int day, string startHour, string endHour)
    {
        Day = day;
        StartHour = startHour;
        EndHour = endHour;
    }
}