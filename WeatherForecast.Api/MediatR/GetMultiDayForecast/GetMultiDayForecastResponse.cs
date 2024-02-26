using WeatherForecast.Api.Domain;

namespace WeatherForecast.Api.MediatR.GetMultiDayForecast;

public record GetMultiDayForecastResponse(List<Forecast> Forecasts);