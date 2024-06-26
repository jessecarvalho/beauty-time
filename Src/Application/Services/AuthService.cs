using System.IdentityModel.Tokens.Jwt;
using Application.DTOs.Authentication;
using Application.DTOs.User;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class AuthService : IAuthService
{
    
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    
    public AuthService(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _tokenService = tokenService;
    }
    
    public async Task<User> GetUserFromRequestAsync(HttpRequest request)
    {
        string authHeader = request.Headers["Authorization"]!;
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            throw new UnauthorizedAccessException("Invalid token.");

        string token = authHeader.Substring("Bearer ".Length).Trim();
        return await GetUserFromTokenAsync(token);
    }
    
    public async Task<string> LoginAsync(LoginRequestDto loginRequest)
    {
        var user = await _userRepository.GetUserByEmailAsync(loginRequest.Email);
        
        if (user is null)
            throw new EmailNotFoundException();
        
        var authenticate = await _userRepository.CheckPasswordAsync(user, loginRequest.Password);
        
        if (!authenticate)
            throw new InvalidPasswordException();
        
        var userDto = _mapper.Map<UserResponseDto>(user);
        var token = _tokenService.GenerateToken(user.Id.ToString());
        return token;
    }

    public async Task<User> GetUserFromTokenAsync(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        
        var userIdClaim = jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub);
        
        var user = await _userRepository.GetByIdAsync(int.Parse(userIdClaim.Value));

        return user;
    }
}