using WeatherForecast.Api.Endpoints;
using WeatherForecast.Api.Extensions;
using WeatherForecast.Api.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDatabase();
builder.Services.ConfigureDI();
builder.Services.ConfigureMediatr();
builder.Services.ConfigureAutomapper();
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureExceptionHandling();
builder.Services.ConfigureApiExplorer();
builder.Services.ConfigureSwagger(builder); 
 
var app = builder.Build();
 
app.UseSwagger();
app.UseSwaggerUI(); 
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

WeatherForecastEndpoints.ConfigureRoutes(app, builder.Configuration);

app.Run();