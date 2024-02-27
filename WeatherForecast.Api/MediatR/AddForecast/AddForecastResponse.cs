namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public record AddForecastResponse(DateOnly date, int temperatureC, int temperatureF, string? summary);