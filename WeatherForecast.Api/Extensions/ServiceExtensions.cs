using FluentValidation;
using MediatR;
using System.Reflection;
using WeatherForecast.Api.Data;
using WeatherForecast.Api.Data.Context;
using WeatherForecast.Api.Data.Interfaces;
using WeatherForecast.Api.Helpers;

namespace WeatherForecast.Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDatabase(this IServiceCollection services)
    {
        services.AddDbContext<ForecastContext>();

        using (var context = new ForecastContext())
        {
            context.Database.EnsureCreated();
        }
    }

    public static void ConfigureDI(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<IForecastRepository, ForecastRepository>();
        
    }

    public static void ConfigureExceptionHandling(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlingMiddleware>();
    }

    public static void ConfigureMediatr(this IServiceCollection services)
    {
        services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); 
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
    }

    public static void ConfigureAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    public static void ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}