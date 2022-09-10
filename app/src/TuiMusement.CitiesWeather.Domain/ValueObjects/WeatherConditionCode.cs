using ValueOf;

namespace TuiMusement.CitiesWeather.Domain.ValueObjects
{
    public class WeatherConditionCode: ValueOf<int, WeatherConditionCode>
    {
        public static WeatherConditionCode Default { get; } = WeatherConditionCode.From(default);
    }
}