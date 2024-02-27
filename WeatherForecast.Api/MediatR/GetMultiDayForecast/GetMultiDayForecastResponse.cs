namespace WeatherForecast.Api.MediatR.GetMultiDayForecast;

public record GetMultiDayForecastResponse(List<MultiDayForecastResponse> Forecasts);

public record MultiDayForecastResponse(DateOnly date, int temperatureC, int temperatureF, string? summary);