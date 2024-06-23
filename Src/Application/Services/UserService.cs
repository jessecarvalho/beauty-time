using Application.DTOs.User;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services;

public class UserService : IUserServices
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponseDto>?> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    public async Task<UserResponseDto> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<UserResponseDto> AddUserAsync(UserRequestDto userRequestDto)
    {
        var emailIsUnique = await _userRepository.GetUserByEmailAsync(userRequestDto.Email);
        
        if (emailIsUnique is not null)
            throw new EmailAlreadyExistsException();
        
        var newUser = await _userRepository.AddAsync(_mapper.Map<User>(userRequestDto));
        
        return _mapper.Map<UserResponseDto>(newUser);
    }

    public async Task<UserResponseDto> UpdateUserAsync(int id, UserRequestDto userRequestDto)
    {
        var emailIsUnique = await _userRepository.GetUserByEmailAsync(userRequestDto.Email);
        
        if (emailIsUnique is not null && emailIsUnique.Id != id)
            throw new EmailAlreadyExistsException();
        
        var updatedUser = await _userRepository.UpdateAsync(id, _mapper.Map<User>(userRequestDto));
        return _mapper.Map<UserResponseDto>(updatedUser);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}