using ValueOf;
namespace TuiMusement.CitiesWeather.Domain.ValueObjects
{
    public class WeatherConditionIcon: ValueOf<string, WeatherConditionIcon>
    {
        public static WeatherConditionIcon Empty { get; } = WeatherConditionIcon.From(string.Empty);
    }
}