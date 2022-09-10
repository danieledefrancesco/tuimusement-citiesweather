using TuiMusement.CitiesWeather.CitiesServiceClient;

namespace TuiMusement.CitiesWeather.Infrastructure.Factories
{
    public interface IClientFactory<T>
    {
        T Create();
    }
}