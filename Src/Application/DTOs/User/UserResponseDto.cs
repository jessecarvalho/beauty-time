using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Application.DTOs.User;

public record UserResponseDto 
{
    public int Id { get; init; } 
    
    public required string Name { get; init; } 
    
    public required string Email { get; init; } 
    
    public required string TelephoneNumber { get; init; }
}