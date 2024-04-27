using Core.Enums;

namespace Application.DTOs;

public record EstablishmentSocialMediaRequestDto()
{
    public SocialMediaEnum SocialMedia { get; set; }
    public EstablishmentResponseDto EstablishmentId { get; set; }
    public string Link { get; set;  }
}