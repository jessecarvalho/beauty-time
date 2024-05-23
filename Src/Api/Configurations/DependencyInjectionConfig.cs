using Application.Interfaces;
using Application.Services;
using Core.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Redis;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace Api.Configurations;

public static class DependencyInjectionConfig
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IEstablishmentService, EstablishmentService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IRedisService, RedisService>();
        
        services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            var configurationOptions = ConfigurationOptions.Parse(configuration["Redis:ConnectionString"], true);
            configurationOptions.AbortOnConnectFail = false;
            return ConnectionMultiplexer.Connect(configurationOptions);
        });
        
        services.AddScoped<IRedisService, RedisService>();
        
    }
}