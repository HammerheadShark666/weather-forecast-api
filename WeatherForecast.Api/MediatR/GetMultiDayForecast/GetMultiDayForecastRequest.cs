using MediatR;

namespace WeatherForecast.Api.MediatR.GetMultiDayForecast;

public record GetMultiDayForecastRequest(DateTime Date, int NumberOfDays) : IRequest<GetMultiDayForecastResponse>;