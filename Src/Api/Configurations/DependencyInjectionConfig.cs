using Application.Interfaces;
using Application.Services;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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
    }
}