using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Core.Enums;

namespace Core.Entities;

public record Establishment
{
    public Establishment() { }
    public Establishment(string name, string logo, string cover, string permalink, string address, ActiveEnum active, int userId)
    {
        Name = name;
        Logo = logo;
        Cover = cover;
        Permalink = permalink;
        Address = address;
        Active = active;
        UserId = userId;
        Services = new List<Service>();
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