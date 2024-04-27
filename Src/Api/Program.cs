using Api.DependencyInjectionConfig;
using Api.Middleware;
using Application.Mappings;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(typeof(ApplicationProfile));
DependencyInjectionConfig.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api V1")    
    );
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
