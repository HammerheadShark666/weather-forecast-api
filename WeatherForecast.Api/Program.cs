using Microsoft.OpenApi.Models;
using System.Reflection;
using WeatherForecast.Api.Endpoints;
using WeatherForecast.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.ConfigureDI(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(builder.Configuration["Api:Version"], new OpenApiInfo { Title = "Weather Forecast API", Description = "Get weather forecast", Version = builder.Configuration["Api:Version"] });
});
 
var app = builder.Build();
 
app.UseSwagger();
app.UseSwaggerUI(); 

app.UseHttpsRedirection();

WeatherForecastEndpoints.ConfigureRoutes(app, builder.Configuration);

app.Run();