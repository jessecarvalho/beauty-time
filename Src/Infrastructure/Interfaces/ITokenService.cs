namespace Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(string userId);
    
}