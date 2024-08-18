using Application.DTOs.User;
using Core.Entities;

namespace Application.Interfaces;

public interface IUserServices
{
    public Task<IEnumerable<UserResponseDto>?> GetAllUsersAsync();
    public Task<UserResponseDto> GetUserByIdAsync(int id);
    public Task<UserResponseDto> AddUserAsync(UserRequestDto user);
    public Task<UserResponseDto> UpdateUserAsync(int id, UserRequestDto user, int loggedUser);
    public Task<bool> DeleteUserAsync(int id);  
}