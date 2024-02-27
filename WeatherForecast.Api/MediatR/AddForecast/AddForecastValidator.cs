using FluentValidation;
using WeatherForecast.Api.Data.Interfaces;
using WeatherForecast.Api.Helpers;

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

        RuleFor(x => x).Must((x, cancellation) =>
        {
            return ValidSummary(x.Summary);
        }).WithMessage($"Summary must be one of the following {string.Join(",", Constants.Summaries.Select(e => "'" + e + "'")) }.");
    }

    private bool ForecastExists(DateOnly date)
    {
        return _forcastRespository.Exists(date);
    }

    private bool ValidSummary(string? summary)
    {
        return Constants.Summaries.Contains(summary);
    }
}