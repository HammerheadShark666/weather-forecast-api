using WeatherForecast.Api.Helpers;

namespace WeatherForecast.Test.Helpers;

public class DateHelperTest
{
    [Fact]
    public void Get_dateonly_for_datetime_return_dateonly()
    {
        var actualResult = DateHelper.GetDateOnly(DateTime.Now);

        Assert.IsType<DateOnly>(actualResult);
    }

    [Fact]
    public void Check_date_in_range_success_return_true()
    {
        var actualResult = DateHelper.DateInRange(DateOnly.FromDateTime(DateTime.Now.AddDays(3)));

        Assert.True(actualResult);
    }

    [Fact]
    public void Check_date_not_in_range_pre_range_fail_return_false()
    {
        var actualResult = DateHelper.DateInRange(DateOnly.FromDateTime(DateTime.Now.AddDays(-1)));

        Assert.False(actualResult);
    }

    [Fact]
    public void Check_date_not_in_range_post_range_fail_return_false()
    {
        var actualResult = DateHelper.DateInRange(DateOnly.FromDateTime(DateTime.Now.AddDays(15)));

        Assert.False(actualResult);
    }

    [Fact]
    public void Get_start_end_date_range_success_return_start_end_dates()
    {
        var numberOfDays = 4;
        var expectedStartDate = DateOnly.FromDateTime(DateTime.Now);
        var expectedEndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(numberOfDays - 1));

        var actualResult = DateHelper.GetStartEndDates(DateOnly.FromDateTime(DateTime.Now), numberOfDays);

        Assert.Equal(expectedStartDate, actualResult.Item1);
        Assert.Equal(expectedEndDate, actualResult.Item2);
    }
}