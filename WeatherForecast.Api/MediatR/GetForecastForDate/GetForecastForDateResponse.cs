using WeatherForecast.Api.Domain;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public record GetForecastForDateResponse(Forecast? Forecast);