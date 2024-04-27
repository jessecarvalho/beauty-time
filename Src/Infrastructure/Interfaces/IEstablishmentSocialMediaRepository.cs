using Core.Entities;

namespace Infrastructure.Interfaces;

public interface IEstablishmentSocialMediaRepository
{
    public Task<IEnumerable<EstablishmentSocialMedia>> GetAllAsync();
    public Task<EstablishmentSocialMedia?> GetByIdAsync(int id);
    public Task<EstablishmentSocialMedia?> AddAsync(EstablishmentSocialMedia establishment);
    public Task<EstablishmentSocialMedia?> UpdateAsync(int id, EstablishmentSocialMedia establishment);
    public Task<bool> RemoveAsync(int id);
}