using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Api.DependencyInjectionConfig;

public static class DependencyInjectionConfig
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
    }
}