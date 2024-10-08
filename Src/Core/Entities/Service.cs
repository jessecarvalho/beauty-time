using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Core.Enums;

namespace Core.Entities;

public record Service
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    [MaxLength(255)]
    public required string Name { get; set; }

    [MaxLength(255)]
    public required string Description { get; set; }

    [Required]
    [MaxLength(255)]
    public required string Icon { get; set; } 

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public required decimal Price { get; set; }

    public required int EstablishmentId { get; init; }

    [Required]
    public required uint TimeInMinutes { get; set; }

    [Required]
    public required ActiveEnum Active { get; set; }

    public required Establishment Establishment { get; set; }

    public Service() { }

    public Service(string name, string description, string icon, decimal price, int establishmentId, uint timeInMinutes, ActiveEnum active, Establishment establishment)
    {
        Name = name;
        Description = description;
        Icon = icon;
        Price = price;
        EstablishmentId = establishmentId;
        TimeInMinutes = timeInMinutes;
        Active = active;
        Establishment = establishment;
    }
}