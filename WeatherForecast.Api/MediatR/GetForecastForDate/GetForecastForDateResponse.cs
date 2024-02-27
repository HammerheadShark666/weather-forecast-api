namespace WeatherForecast.Api.MediatR.GetForecastForDate;
 
public record GetForecastForDateResponse(DateOnly date, int temperatureC, int temperatureF, string? summary);