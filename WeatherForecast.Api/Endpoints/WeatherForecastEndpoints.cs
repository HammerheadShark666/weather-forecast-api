using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using WeatherForecast.Api.Model;
using WeatherForecast.Api.Services.Interfaces;

namespace WeatherForecast.Api.Endpoints;

public static class WeatherForecastEndpoints
{
    public static void ConfigureRoutes(this WebApplication app)
    {
        app.MapGet("/weather-forecast/5-day", (IWeatherForecastService weatherForecastService) => {
            return weatherForecastService.GetForecast(DateTime.Now, 5);
        })
       .Produces<Forecast[]>()
       .Produces(404)
       .WithName("Get5DayWeatherForecast")
       .WithOpenApi(x => new OpenApiOperation(x)
       {
           Summary = "Get 5 day weather forecast.",
           Description = "Returns weather forecast for 5 days.",
           Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } }
       });

       app.MapGet("/weather-forecast", (DateTime date, IWeatherForecastService weatherForecastService) => {
            return weatherForecastService.GetForecast(date); 
       })
       .Produces<Forecast>()
       .Produces(404)
       .WithName("GetWeatherForecastByDate")
       .WithOpenApi(generatedOperation =>
       {
           var parameter = generatedOperation.Parameters[0];
           parameter.Description = "Date weather forecast required for.";
           parameter.In = ParameterLocation.Query;
           parameter.Schema = new OpenApiSchema { Type = "string", Format = "date-time", Example = new OpenApiString("2024-01-23") };
           parameter.Required = true;
           parameter.Example = new OpenApiString("2024-01-23");

           generatedOperation.Summary = "Get weather forecast for date.";
           generatedOperation.Description = "Returns weather forecast for date.";
           generatedOperation.Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } };

           return generatedOperation;
       });

       app.MapGet("/weather-forecast/today", (IWeatherForecastService weatherForecastService) => {
            return weatherForecastService.GetForecast(DateTime.Now);
       })
       .Produces<Forecast>()
       .Produces(404)
       .WithName("GetWeatherForecastToday")
       .WithOpenApi(generatedOperation =>
       { 
           generatedOperation.Summary = "Get weather forecast for today.";
           generatedOperation.Description = "Returns weather forecast for today.";
           generatedOperation.Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } };

           return generatedOperation;
       });

       app.MapGet("/weather-forecast/from-today", (int numberofdays, IWeatherForecastService weatherForecastService) => {
            return weatherForecastService.GetForecast(DateTime.Now, numberofdays);
       })
       .Produces<Forecast[]>()
       .Produces(404)
       .WithName("GetWeatherForecastFromTodayForNumberOfDays")
       .WithOpenApi(generatedOperation =>
       {
           var parameter = generatedOperation.Parameters[0];
           parameter.Description = "Number of days weather forecast required from today.";
           parameter.In = ParameterLocation.Query;
           parameter.Schema = new OpenApiSchema { Type = "int", Example = new OpenApiString("2") };
           parameter.Required = true;
           parameter.Example = new OpenApiString("2");

           generatedOperation.Summary = "Get weather forecast for number of days from today.";
           generatedOperation.Description = "Returns weather forecast for number of days from today.";
           generatedOperation.Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } };

           return generatedOperation;
       });
    }
}
