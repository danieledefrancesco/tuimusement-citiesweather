using ValueOf;

namespace TuiMusement.CitiesWeather.Domain.ValueObjects
{
    public class Longitude: ValueOf<double, Longitude>
    {
        public static Longitude Default { get; } = Longitude.From(default);

    }
}