using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Core.Enums;

namespace Core.Entities;

public record Service
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
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
    
    public int EstablishmentId { get; set; }
    
    [Required]
    public uint TimeInMinutes { get; set; }
    
    [Required]
    public ActiveEnum Active { get; set; }
    public Establishment Establishment { get; set; }
}