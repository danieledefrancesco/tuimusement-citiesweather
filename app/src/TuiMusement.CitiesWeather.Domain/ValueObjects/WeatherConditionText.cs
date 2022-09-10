using ValueOf;

namespace TuiMusement.CitiesWeather.Domain.ValueObjects
{
    public class WeatherConditionText: ValueOf<string, WeatherConditionText>
    {
        public static WeatherConditionText Empty { get; } = WeatherConditionText.From(string.Empty);
    }
}