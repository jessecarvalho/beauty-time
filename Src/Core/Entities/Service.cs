using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Core.Enums;

namespace Core.Entities;

public record Service
{
    public BigInteger Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    [MaxLength(255)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Icon { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    
    public BigInteger EstablishmentId { get; set; }
    
    [Required]
    public uint TimeInMinutes { get; set; }
    
    [Required]
    public ActiveEnum Active { get; set; }
    public Establishment Establishment { get; set; }
}