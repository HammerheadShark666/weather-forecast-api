namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public record AddForecastResponse(long id, DateOnly date, int temperatureC, int temperatureF, string? summary);