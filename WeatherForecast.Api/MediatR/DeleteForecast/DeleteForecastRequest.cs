using MediatR;

namespace WeatherForecast.Api.MediatR.DeleteForecast;

public record DeleteForecastRequest(long Id) : IRequest<Unit>;                            