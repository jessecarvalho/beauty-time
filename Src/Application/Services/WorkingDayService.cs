using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;

namespace Application.Services;

public class WorkingDayService : IWorkingDayService
{
    private readonly IWorkingDayRepository _workingDayRepository;
    private readonly IMapper _mapper;
    
    public WorkingDayService(IWorkingDayRepository workingDayRepository, IMapper mapper)
    {
        _workingDayRepository = workingDayRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<WorkingDayResponseDto>?> GetAllAsync()
    {
        var workingDays = await _workingDayRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<WorkingDayResponseDto>>(workingDays);
    }

    public async Task<WorkingDayResponseDto> GetByIdAsync(int id)
    {
        var workingDay = await _workingDayRepository.GetByIdAsync(id);

        return _mapper.Map<WorkingDayResponseDto>(workingDay);
    }

    public async Task<WorkingDayResponseDto> CreateAsync(WorkingDayRequestDto workingDay, User user)
    {
        var mappedWorkingDay = _mapper.Map<Core.Entities.WorkingDay>(workingDay);
        var newWorkingDay = await _workingDayRepository.AddAsync(mappedWorkingDay, user);
        
        return _mapper.Map<WorkingDayResponseDto>(newWorkingDay);
    }

    public async Task<WorkingDayResponseDto> UpdateAsync(int id, WorkingDayRequestDto workingDay, User user)
    {
        var mappedWorkingDay = _mapper.Map<Core.Entities.WorkingDay>(workingDay);
        var updatedWorkingDay = await _workingDayRepository.UpdateAsync(id, mappedWorkingDay, user);
        
        return _mapper.Map<WorkingDayResponseDto>(updatedWorkingDay);
    }

    public async Task<bool> DeleteAsync(int id, User user)
    {
        return await _workingDayRepository.DeleteAsync(id, user);
    }
    
}