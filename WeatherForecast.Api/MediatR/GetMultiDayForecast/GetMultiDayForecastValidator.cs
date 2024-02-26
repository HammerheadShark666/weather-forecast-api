using FluentValidation;
using WeatherForecast.Api.Helpers;

namespace WeatherForecast.Api.MediatR.GetMultiDayForecast;

public class GetMultiDayForecastValidator : AbstractValidator<GetMultiDayForecastRequest>
{

    private string NumberOfDaysMessage = $"Number of days must be 1 to { Constants.NumberOfDaysForecastAvailable }.";

    public GetMultiDayForecastValidator()
    {
        RuleFor(x => x.NumberOfDays)
            .InclusiveBetween(1, Constants.NumberOfDaysForecastAvailable).WithMessage(NumberOfDaysMessage);

        RuleFor(x => x).Must((x, cancellation) => {
            return DateHelper.DateInRange(DateOnly.FromDateTime(x.Date));
        }).WithMessage($"Date has to be within { Constants.NumberOfDaysForecastAvailable } days of today");
    }
}