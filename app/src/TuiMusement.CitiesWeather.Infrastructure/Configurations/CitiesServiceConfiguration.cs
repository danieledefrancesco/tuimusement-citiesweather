namespace TuiMusement.CitiesWeather.Infrastructure.Configurations
{
    public class CitiesServiceConfiguration: IBaseUrlConfig
    {
        public string BaseUrl { get; set; } = string.Empty;
    }
}