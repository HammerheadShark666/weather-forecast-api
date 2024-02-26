using MediatR;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using WeatherForecast.Api.Helpers;
using WeatherForecast.Api.MediatR.GetForecastForDate;
using WeatherForecast.Api.MediatR.GetMultiDayForecast;
using WeatherForecast.Api.Domain;
using WeatherForecast.Api.MediatR.AddForecast;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Api.MediatR.DeleteForecast;

namespace WeatherForecast.Api.Endpoints;

public static class WeatherForecastEndpoints
{
    public static void ConfigureRoutes(this WebApplication app, ConfigurationManager configuration)
    {
        var apiPrefix = $"api/{configuration["Api:Version"]}/";

        app.MapGet($"{apiPrefix}weather-forecast/5-day", async (IMediator mediator) => {
            GetMultiDayForecastResponse result = await mediator.Send(new GetMultiDayForecastRequest(DateTime.Now, 5));
            return result.Forecasts == null ? Results.NotFound() : Results.Ok(result);
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

        app.MapGet($"{apiPrefix}weather-forecast", async (IMediator mediator, DateTime date) => {
            AddForecastResponse result = await mediator.Send(new GetForecastForDateRequest(date));
            return result.Forecast == null ? Results.NotFound() : Results.Ok(result);
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

        app.MapGet($"{apiPrefix}weather-forecast/today", async (IMediator mediator) => {
            AddForecastResponse result = await mediator.Send(new GetForecastForDateRequest(DateTime.Now));
            return result.Forecast == null ? Results.NotFound() : Results.Ok(result);
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

        app.MapGet($"{apiPrefix}weather-forecast/from", async (IMediator mediator, DateTime fromDate, int numberOfDays) => {
            GetMultiDayForecastResponse result = await mediator.Send(new GetMultiDayForecastRequest(fromDate, numberOfDays));
            return result.Forecasts == null ? Results.NotFound() : Results.Ok(result);
        })
        .Produces<Forecast[]>()
        .Produces(404)
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
        .Produces<Forecast[]>()
        .Produces(404)
        .WithName("AddForecast");
        //.WithOpenApi(generatedOperation =>
        //{

        //    generatedOperation.Tags = new[] { new OpenApiTag { Name = "test" } };
        //    generatedOperation.RequestBody = new OpenApiRequestBody
        //    {
        //        Content = new Dictionary<string, OpenApiMediaType>
        //        {
        //            ["application/json"] = new OpenApiMediaType
        //            {
        //                Schema = context.SchemaGenerator.GenerateSchema(typeof(AddForecastRequest), context.SchemaRepository)
        //            }
        //        }
        //    };

        //    //generatedOperation.RequestBody = new OpenApiRequestBody()
        //    //{
        //    //    C
        //    //};

        //    return generatedOperation;
        //});


        //.WithOpenApi(generatedOperation =>
        //{
        //    var parameterDate = generatedOperation.Parameters[0];
        //    parameterDate.Description = $"Date of forecast.";
        //    parameterDate.In = ParameterLocation.Query;
        //    parameterDate.Schema = new OpenApiSchema { Type = "string", Format = "date-time", Example = new OpenApiString("2024-01-23") };
        //    parameterDate.Required = true;
        //    parameterDate.Example = new OpenApiString("2024-01-23");

        //    var parameterTempratureC = generatedOperation.Parameters[1];
        //    parameterTempratureC.Description = $"Temprature in centigrade";
        //    parameterTempratureC.In = ParameterLocation.Query;
        //    parameterTempratureC.Schema = new OpenApiSchema { Type = "int", Example = new OpenApiString("4") };
        //    parameterTempratureC.Required = true;
        //    parameterTempratureC.Example = new OpenApiString("45");

        //    var parameterSummary = generatedOperation.Parameters[1];
        //    parameterSummary.Description = $"Summary of forecast";
        //    parameterSummary.In = ParameterLocation.Query;
        //    parameterSummary.Schema = new OpenApiSchema { Type = "string", Example = new OpenApiString("Cloudy") };
        //    parameterSummary.Required = false;
        //    parameterSummary.Example = new OpenApiString("cloudy");

        //    generatedOperation.Summary = "Add a forecast for a day that doesn't have one.";
        //    generatedOperation.Description = "Add a forecast for a day that doesn't have one.";
        //    generatedOperation.Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } };

        //    return generatedOperation;
        //});

        //app.MapPost($"{apiPrefix}weather-forecast", async (IMediator mediator, DateTime fromDate, int temperatureC, string? summary) => {
        //    await mediator.Send(new AddForecastRequest(fromDate, temperatureC, summary));
        //    return Results.Ok();
        //})
        //.Produces<Forecast[]>()
        //.Produces(404)
        //.WithName("AddForecast")
        //.WithOpenApi(generatedOperation =>
        //{
        //    var parameterDate = generatedOperation.Parameters[0];
        //    parameterDate.Description = $"Date of forecast.";
        //    parameterDate.In = ParameterLocation.Query;
        //    parameterDate.Schema = new OpenApiSchema { Type = "string", Format = "date-time", Example = new OpenApiString("2024-01-23") };
        //    parameterDate.Required = true;
        //    parameterDate.Example = new OpenApiString("2024-01-23");

        //    var parameterTempratureC = generatedOperation.Parameters[1];
        //    parameterTempratureC.Description = $"Temprature in centigrade";
        //    parameterTempratureC.In = ParameterLocation.Query;
        //    parameterTempratureC.Schema = new OpenApiSchema { Type = "int", Example = new OpenApiString("4") };
        //    parameterTempratureC.Required = true;
        //    parameterTempratureC.Example = new OpenApiString("45");

        //    var parameterSummary = generatedOperation.Parameters[1];
        //    parameterSummary.Description = $"Summary of forecast";
        //    parameterSummary.In = ParameterLocation.Query;
        //    parameterSummary.Schema = new OpenApiSchema { Type = "string", Example = new OpenApiString("Cloudy") };
        //    parameterSummary.Required = false;
        //    parameterSummary.Example = new OpenApiString("cloudy");

        //    generatedOperation.Summary = "Add a forecast for a day that doesn't have one.";
        //    generatedOperation.Description = "Add a forecast for a day that doesn't have one.";
        //    generatedOperation.Tags = new List<OpenApiTag> { new() { Name = "Weather Forecast" } };

        //    return generatedOperation;
        //});


        app.MapDelete($"{apiPrefix}weather-forecast", async (IMediator mediator, long id) => {
            await mediator.Send(new DeleteForecastRequest(id));
            return Results.Ok();
        })
        .Produces<Forecast[]>()
        .Produces(404)
        .WithName("DeleteForecast");



    }
}