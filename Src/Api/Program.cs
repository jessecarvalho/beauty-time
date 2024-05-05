using Api.Configurations;
using Api.Middleware;
using Application.Mappings;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(typeof(ApplicationProfile));
DependencyInjectionConfig.Configure(builder.Services, builder.Configuration);
JwtConfig.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api V1")    
    );
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
// app.UseHttpsRedirection();

app.Run();
