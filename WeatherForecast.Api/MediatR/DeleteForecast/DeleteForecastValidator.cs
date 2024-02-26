using FluentValidation;
using WeatherForecast.Api.Data.Interfaces;

namespace WeatherForecast.Api.MediatR.DeleteForecast;

public class DeleteForecastValidator : AbstractValidator<DeleteForecastRequest>
{
    private readonly IForecastRepository _forcastRespository;

    public DeleteForecastValidator(IForecastRepository forecastRepository)
    {
        _forcastRespository = forecastRepository;

        RuleFor(x => x).Must((x, cancellation) =>
        {
            return ForecastExists(x.Id);
        }).WithMessage($"Forecast not found");
    }

    private bool ForecastExists(long id)
    {
        return _forcastRespository.Exists(id);
    }
}