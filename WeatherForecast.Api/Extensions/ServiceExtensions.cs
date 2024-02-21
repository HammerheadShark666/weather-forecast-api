using WeatherForecast.Api.Data;
using WeatherForecast.Api.Data.Interfaces;
using WeatherForecast.Api.Services;
using WeatherForecast.Api.Services.Interfaces;

namespace WeatherForecast.Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDI(this IServiceCollection services)
    {
        services.AddScoped<IForecastRepository, ForecastRepository>();
        services.AddScoped<IWeatherForecastService, WeatherForecastService>(); 
    }
}