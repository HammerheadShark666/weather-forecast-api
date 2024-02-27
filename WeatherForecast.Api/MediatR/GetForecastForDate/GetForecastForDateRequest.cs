using MediatR;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public record GetForecastForDateRequest(DateTime Date) : IRequest<GetForecastForDateResponse>;