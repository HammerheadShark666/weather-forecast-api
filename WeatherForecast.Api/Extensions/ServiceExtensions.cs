using WeatherForecast.Api.Services;
using WeatherForecast.Api.Services.Interfaces;

namespace WeatherForecast.Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDI(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>(); 
    }
}
