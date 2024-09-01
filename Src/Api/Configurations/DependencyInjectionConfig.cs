using Application.Interfaces;
using Application.Services;
using Core.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Redis;
using Infrastructure.Repositories;
using Infrastructure.Services;
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
        services.AddScoped<IEstablishmentService, EstablishmentService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IUserServices, UserService>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRedisService, RedisService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IWorkingDayService, WorkingDayService>();
        services.AddScoped<IWorkingDayRepository, WorkingDayRepository>();
        

        
        services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            var configurationOptions = ConfigurationOptions.Parse(configuration["Redis:ConnectionString"]!, true);
            configurationOptions.AbortOnConnectFail = false;
            return ConnectionMultiplexer.Connect(configurationOptions);
        });
        
        services.AddScoped<IRedisService, RedisService>();
        
    }
}