using Application.DTOs.Authentication;
using Application.DTOs.User;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<string> LoginAsync(LoginRequestDto loginRequest);
    Task<User> GetUserFromRequestAsync(HttpRequest request);
}