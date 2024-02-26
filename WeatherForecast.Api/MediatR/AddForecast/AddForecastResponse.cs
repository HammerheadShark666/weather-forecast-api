using WeatherForecast.Api.Domain;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public record AddForecastResponse(Forecast? Forecast);