using Core.Enums;

namespace Application.DTOs;

public record WorkingDayRequestDto
{
    public WorkingDayEnum Day { get; set; }
    public string StartHour { get; set; }
    public string EndHour { get; set; }
    
    public WorkingDayRequestDto(WorkingDayEnum day, string startHour, string endHour)
    {
        Day = day;
        StartHour = startHour;
        EndHour = endHour;
    }
}