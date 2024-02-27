using WeatherForecast.Api.Helpers;

namespace WeatherForecast.Test.Helpers;

public class DateHelperTest
{
    [Fact]
    public void Get_dateonly_for_datetime_return_dateonly()
    {
        var dateOnly = DateHelper.GetDateOnly(DateTime.Now);

        Assert.IsType<DateOnly>(dateOnly);
    }

    [Fact]
    public void Check_date_in_range_success_return_true()
    {
        var response = DateHelper.DateInRange(DateOnly.FromDateTime(DateTime.Now.AddDays(3)));

        Assert.True(response);
    }

    [Fact]
    public void Check_date_not_in_range_pre_range_fail_return_false()
    {
        var response = DateHelper.DateInRange(DateOnly.FromDateTime(DateTime.Now.AddDays(-1)));

        Assert.False(response);
    }

    [Fact]
    public void Check_date_not_in_range_post_range_fail_return_false()
    {
        var response = DateHelper.DateInRange(DateOnly.FromDateTime(DateTime.Now.AddDays(15)));

        Assert.False(response);
    }

    [Fact]
    public void Get_start_end_date_range_success_return_start_end_dates()
    {
        int numberOfDays = 4;

        var response = DateHelper.GetStartEndDates(DateOnly.FromDateTime(DateTime.Now), numberOfDays);

        Assert.Equal(DateOnly.FromDateTime(DateTime.Now), response.Item1);
        Assert.Equal(DateOnly.FromDateTime(DateTime.Now.AddDays(numberOfDays-1)), response.Item2);
    }
}