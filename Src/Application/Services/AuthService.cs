using Application.DTOs.Authentication;
using Application.DTOs.User;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

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
}