using Core.Enums;

namespace Application.DTOs;

public record WorkingDayResponseDto
{
    public int Id { get; set; }
    public WorkingDayEnum Day { get; set; }
    public string StartHour { get; set; }
    public string EndHour { get; set; }
    public int EstablishmentId { get; set; }
    
    public WorkingDayResponseDto(int id, WorkingDayEnum day, string startHour, string endHour, int establishmentId)
    {
        Id = id;
        Day = day;
        StartHour = startHour;
        EndHour = endHour;
        EstablishmentId = establishmentId;
    }
}