using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Redis
{
    public class RedisService : IRedisService
    {
        private readonly IConfiguration _configuration;
        private IDatabase _database;

        public RedisService(IConfiguration configuration)
        {
            _configuration = configuration;
            var redisConnectionString = _configuration["Redis:ConnectionString"];
            var options = ConfigurationOptions.Parse(redisConnectionString ?? throw new InvalidOperationException());
            options.AbortOnConnectFail = false;
            options.SyncTimeout = 10000; // Increase timeout to 10 seconds
            var redis = ConnectionMultiplexer.Connect(options);
            _database = redis.GetDatabase();
        }

        public async Task SetValueAsync(string key, string value, TimeSpan expiration)
        {
            await _database.StringSetAsync(key, value, expiry: expiration);
        }

        public async Task<string?> GetValueAsync(string key)
        {
            return await _database.StringGetAsync(key);
        }

        public async Task DeleteKeyAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }
        
        public async Task<bool> CheckConnectionAsync()
        {
            return await _database.PingAsync() != TimeSpan.Zero;
        }
    }
}