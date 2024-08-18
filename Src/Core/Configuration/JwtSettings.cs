namespace Core.Configuration;

public class JwtSettings()
{
    public required string SecretKey { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; } 
    public required int ExpiryInMinutes { get; init; } 
}