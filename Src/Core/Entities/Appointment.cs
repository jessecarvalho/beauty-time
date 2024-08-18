using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public record Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Required]
        public required int EstablishmentId { get; set; }
        
        [Required]
        public required int UserId { get; set; }

        [Required]
        public required DateTime Date { get; set; }

        public required Establishment? Establishment { get; init; }

        public required User? User { get; init; }

    }
}