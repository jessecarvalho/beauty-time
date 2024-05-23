namespace Core.Interfaces;

public interface IRedisService
{
    public Task SetValueAsync(string key, string value, TimeSpan expiration);
    public Task<string?> GetValueAsync(string key);
    public Task DeleteKeyAsync(string key);
    
    public Task<bool> CheckConnectionAsync();
}