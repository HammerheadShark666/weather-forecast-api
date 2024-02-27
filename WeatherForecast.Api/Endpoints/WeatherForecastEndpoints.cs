using MediatR;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Net;
using WeatherForecast.Api.Helpers;
using WeatherForecast.Api.MediatR.AddForecast;
using WeatherForecast.Api.MediatR.DeleteForecast;
using WeatherForecast.Api.MediatR.GetForecastForDate;
using WeatherForecast.Api.MediatR.GetMultiDayForecast;

namespace WeatherForecast.Api.Endpoints;

public static class WeatherForecastEndpoints
{
    public static void ConfigureRoutes(this WebApplication app, ConfigurationManager configuration)
    {
        var apiPrefix = $"api/{configuration["Api:Version"]}/";

        app.MapGet($"{apiPrefix}weather-forecast/5-day", async (IMediator mediator) => {
            var result = await mediator.Send(new GetMultiDayForecastRequest(DateTime.Now, 5));
            return result.Forecasts == null ? Results.NotFound() : Results.Ok(result);
        })
        .Produces<GetMultiDayForecastResponse>()
        .Produces((int)HttpStatusCode.NotFound)
        .Produces<List<string>>((int)HttpStatusCode.BadRequest)
        .WithName("Get5DayWeatherForecast")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Get 5 day weather forecast.",
            Description = "Returns weather forecast for 5 days.",
            Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } }
        });

        app.MapGet($"{apiPrefix}weather-forecast", async (IMediator mediator, DateTime date) => {
            var result = await mediator.Send(new GetForecastForDateRequest(date));
            return result == null ? Results.NotFound() : Results.Ok(result);
        })        
        .Produces<GetForecastForDateResponse>()
        .Produces((int)HttpStatusCode.NotFound)
        .Produces<List<string>>((int)HttpStatusCode.BadRequest)
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

        app.MapGet($"{apiPrefix}weather-forecast/today", async (IMediator mediator) => {
            var result = await mediator.Send(new GetForecastForDateRequest(DateTime.Now));
            return result == null ? Results.NotFound() : Results.Ok(result);
        })
        .Produces<GetForecastForDateResponse>()
        .Produces((int)HttpStatusCode.NotFound)
        .Produces<List<string>>((int)HttpStatusCode.BadRequest)
        .WithName("GetWeatherForecastToday")
        .WithOpenApi(generatedOperation =>
        {
            generatedOperation.Summary = "Get weather forecast for today.";
            generatedOperation.Description = "Returns weather forecast for today.";
            generatedOperation.Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } };

            return generatedOperation;
        });

        app.MapGet($"{apiPrefix}weather-forecast/from", async (IMediator mediator, DateTime fromDate, int numberOfDays) => {
            var result = await mediator.Send(new GetMultiDayForecastRequest(fromDate, numberOfDays));
            return result.Forecasts == null ? Results.NotFound() : Results.Ok(result);
        }) 
        .Produces<GetMultiDayForecastResponse>()
        .Produces((int)HttpStatusCode.NotFound)
        .Produces<List<string>>((int)HttpStatusCode.BadRequest)
        .WithName("GetWeatherForecastFromDateForNumberOfDays")
        .WithOpenApi(generatedOperation =>
        {
            var parameterDate = generatedOperation.Parameters[0];
            parameterDate.Description = $"From date of weather forecast, within {Constants.NumberOfDaysForecastAvailable} days.";
            parameterDate.In = ParameterLocation.Query;
            parameterDate.Schema = new OpenApiSchema { Type = "string", Format = "date-time", Example = new OpenApiString("2024-01-23") };
            parameterDate.Required = true;
            parameterDate.Example = new OpenApiString("2024-01-23");

            var parameterNumberOfDays = generatedOperation.Parameters[1];
            parameterNumberOfDays.Description = $"Number of days weather forecast required from date.";
            parameterNumberOfDays.In = ParameterLocation.Query;
            parameterNumberOfDays.Schema = new OpenApiSchema { Type = "int", Example = new OpenApiString("4") };
            parameterNumberOfDays.Required = true;
            parameterNumberOfDays.Example = new OpenApiString("4"); 

            generatedOperation.Summary = $"Get weather forecast for number of days from date, within {Constants.NumberOfDaysForecastAvailable} days.";
            generatedOperation.Description = $"Returns weather forecast for number of days from date, within {Constants.NumberOfDaysForecastAvailable} days.";
            generatedOperation.Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } };

            return generatedOperation;
        });

        app.MapPost($"{apiPrefix}weather-forecast", async (AddForecastRequest addForecastRequest, IMediator mediator) => {
            var forecast = await mediator.Send(addForecastRequest);
            return Results.Ok(forecast);
        })
        .Accepts<AddForecastRequest>("application/json")
        .Produces<AddForecastResponse>((int)HttpStatusCode.OK)
        .Produces<List<string>>((int)HttpStatusCode.BadRequest)
        .WithName("AddForecast")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Add a forecast. Summary should be one of the following, 'Bracing','Chilly','Cool','Mild','Warm','Balmy','Hot','Sweltering','Scorching'",
            Description = "Returns added forecast.",
            Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } }
        }); 

        app.MapDelete($"{apiPrefix}weather-forecast", async (IMediator mediator, long id) =>
        {
            await mediator.Send(new DeleteForecastRequest(id));
            return Results.Ok();
        })        
        .Produces((int)HttpStatusCode.OK)
        .Produces((int)HttpStatusCode.NotFound)
        .Produces<List<string>>((int)HttpStatusCode.BadRequest)
        .WithName("DeleteForecast")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Deletes a forecast.",
            Description = "Returns nothing",
            Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } }
        }); 
    }
}