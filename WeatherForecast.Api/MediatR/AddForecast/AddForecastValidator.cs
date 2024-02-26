using FluentValidation;
using WeatherForecast.Api.Data.Interfaces;

namespace WeatherForecast.Api.MediatR.AddForecast;

public class AddForecastValidator : AbstractValidator<AddForecastRequest>
{
    private readonly IForecastRepository _forcastRespository;

    public AddForecastValidator(IForecastRepository forecastRepository)
    {
        _forcastRespository = forecastRepository;

        RuleFor(x => x).Must((x, cancellation) =>
        {
            return !ForecastExists(x.Date);
        }).WithMessage($"Forecast already exists with this date");
    }

    private bool ForecastExists(DateOnly date)
    {
        return _forcastRespository.Exists(date);
    }
}