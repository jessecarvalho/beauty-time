using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Core.Entities;

public record Appointment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public int EstablishmentId { get; set; }
    
    [Required]
    public int ClientId { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    public Establishment Establishment { get; set; }
    
    public Client Client { get; set; }
}