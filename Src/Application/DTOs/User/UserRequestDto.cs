using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Application.DTOs.User;

public record UserRequestDto
{
    public required string Name { get; set; } 
    public required string Email { get; set; } 
    public required string Password { get; set; }
    public required string TelephoneNumber { get; set; }
}