using System.Numerics;
using Core.Enums;

namespace Core.Entities;

public record EstablishmentSocialMedia
{
    public BigInteger Id { get; set; }
    public SocialMediaEnum SocialMedia { get; set; }
    public Establishment EstablishmentId { get; set; }
    public string Link { get; set;  }
}