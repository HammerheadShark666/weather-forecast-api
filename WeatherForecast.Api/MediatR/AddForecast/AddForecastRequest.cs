using MediatR;
using WeatherForecast.Api.Domain;
using WeatherForecast.Api.MediatR.GetForecastForDate;

namespace WeatherForecast.Api.MediatR.AddForecast;

public record AddForecastRequest(DateOnly Date, int TemperatureC, string? Summary) : IRequest<AddForecastResponse>;                            