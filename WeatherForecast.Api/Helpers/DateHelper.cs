namespace WeatherForecast.Api.Helpers;

public static class DateHelper
{
    public static DateOnly GetDateOnly(this DateTime date)
    {
        return DateOnly.FromDateTime(date);
    }

    public static bool DateInRange(DateOnly date)
    {
        var dates = GetStartEndDates(DateOnly.FromDateTime(DateTime.Now), Constants.NumberOfDaysForecastAvailable);

        if (date >= dates.Item1 && date < dates.Item2)
        {
            return true;
        }

        return false;
    }

    public static Tuple<DateOnly, DateOnly> GetStartEndDates(DateOnly date, int numberOfDaysInbetween)
    {
        var dateMinLimit = date;
        var dateMaxLimit = date.AddDays(numberOfDaysInbetween-1);

        return new Tuple<DateOnly, DateOnly>(dateMinLimit, dateMaxLimit);
    }
}