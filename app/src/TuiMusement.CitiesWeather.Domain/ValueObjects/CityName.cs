using ValueOf;

namespace TuiMusement.CitiesWeather.Domain.ValueObjects
{
    public class CityName: ValueOf<string, CityName>
    {
        public static CityName Empty { get; } = CityName.From(string.Empty);
    }
}