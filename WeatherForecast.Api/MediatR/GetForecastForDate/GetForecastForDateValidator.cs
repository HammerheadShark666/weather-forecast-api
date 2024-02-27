using FluentValidation;
using WeatherForecast.Api.Helpers;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public class GetForecastForDateValidator : AbstractValidator<GetForecastForDateRequest>
{
    public GetForecastForDateValidator()
    {
        RuleFor(x => x).Must((x, cancellation) => {
            return DateHelper.DateInRange(DateOnly.FromDateTime(x.Date));
        }).WithMessage($"Date has to be within {Constants.NumberOfDaysForecastAvailable} days of today");
    }
}