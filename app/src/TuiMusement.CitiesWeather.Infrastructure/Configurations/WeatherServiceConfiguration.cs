namespace TuiMusement.CitiesWeather.Infrastructure.Configurations
{
    public class WeatherServiceConfiguration: IBaseUrlConfig
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
    }
}