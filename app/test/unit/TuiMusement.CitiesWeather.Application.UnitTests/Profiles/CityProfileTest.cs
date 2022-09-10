using AutoMapper;
using NUnit.Framework;
using TuiMusement.CitiesWeather.Application.Profiles;

namespace TuiMusement.CitiesWeather.Application.UnitTests.Profiles
{
    public class CityProfileTest
    {
        private MapperConfiguration? _mapperConfiguration;

        [SetUp]
        public void SetUp()
        {
            _mapperConfiguration = new MapperConfiguration(
                cfg => cfg.AddProfile<CityProfile>());
        }

        [Test]
        public void Configuration_IsValid()
        {
            _mapperConfiguration!.AssertConfigurationIsValid();
        }
    }
}