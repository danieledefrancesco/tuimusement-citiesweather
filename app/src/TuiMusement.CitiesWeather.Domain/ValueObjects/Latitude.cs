using ValueOf;

namespace TuiMusement.CitiesWeather.Domain.ValueObjects
{
    public class Latitude: ValueOf<double, Latitude>
    {
        public static Latitude Default { get; } = Latitude.From(default);
    }
}