using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using TuiMusement.CitiesWeather.CitiesServiceClient.Models;
using VerifyNUnit;

namespace TuiMusement.CitiesWeather.CitiesServiceClient.UnitTests.Models
{
    public class CityDtoTest
    {
        [Test]
        public async Task DeserializeJson_ShouldMatchSnapshot()
        {
            var assembly = typeof(CityDtoTest).Assembly;
            var resourceName = $"{assembly.GetName().Name}.cityDto.json";
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream!);
            string resourceText = reader.ReadToEnd();
            var cityDto = JsonConvert.DeserializeObject<CityDto>(resourceText);
            await Verifier.Verify(cityDto);
        }
    }
}