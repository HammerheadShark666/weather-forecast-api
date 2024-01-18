using Microsoft.OpenApi.Models;
using WeatherForecast.Api.Endpoints;
using WeatherForecast.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDI(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather Forecast API", Description = "Get weather forecast", Version = "v1" });
});
 
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

WeatherForecastEndpoints.ConfigureRoutes(app);

app.Run();