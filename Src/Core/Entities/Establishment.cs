using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Core.Enums;

namespace Core.Entities;

public record Establishment
{
    public Establishment(List<Service>? services)
    {
        Services = services;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    [MaxLength(255)]
    public required string Name { get; set; }

    [MaxLength(255)]
    public required string Logo { get; set; }

    [MaxLength(255)]
    public required string Cover { get; set; }

    [Required]
    [MaxLength(255)]
    public required string Permalink { get; set; } 

    [Required]
    [MaxLength(255)]
    public required string Address { get; set; }

    [Required]
    public required ActiveEnum Active { get; set; }
    
    [Required]
    public required int UserId { get; set; }

    public List<Service>? Services { get; set; }

    public required User User { get; init; }

}