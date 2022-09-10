using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using TuiMusement.CitiesWeather.WeatherServiceClient.Models;
using VerifyNUnit;

namespace TuiMusement.CitiesWeather.WeatherServiceClient.UnitTests.Models
{
    public class WeatherForecastResponseDtoTest
    {
        [Test]
        public async Task DeserializeJson_ShouldMatchSnapshot()
        {
            var assembly = typeof(WeatherForecastResponseDtoTest).Assembly;
            var resourceName = $"{assembly.GetName().Name}.weatherForecastResponseDto.json";
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream!);
            string resourceText = reader.ReadToEnd();
            var cityDto = JsonConvert.DeserializeObject<WeatherForecastResponseDto>(resourceText);
            await Verifier.Verify(cityDto);
        }
    }
}