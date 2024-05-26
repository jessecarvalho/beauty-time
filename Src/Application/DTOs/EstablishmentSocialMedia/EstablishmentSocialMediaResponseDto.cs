using System.Numerics;
using Core.Enums;

namespace Application.DTOs;

public record EstablishmentSocialMediaResponseDto()
{
    public int Id { get; set; }
    public SocialMediaEnum SocialMedia { get; set; }
    public EstablishmentResponseDto EstablishmentId { get; set; }
    public string Link { get; set;  }
}