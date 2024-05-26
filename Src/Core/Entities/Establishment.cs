using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Core.Enums;

namespace Core.Entities;

public record Establishment
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    [MaxLength(255)]
    public string Logo { get; set; }
    
    [MaxLength(255)]
    public string Cover { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Permalink { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Address { get; set; }
    
    [Required]
    public ActiveEnum Active { get; set; }
    
    public List<Appointment> Appointments { get; set; }
    
    public List<Client> Clients { get; set; }
    public List<Service> Services { get; set; }
}