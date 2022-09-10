using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;

namespace TuiMusement.CitiesWeather.Infrastructure.UnitTests
{
    public class DependencyInjectionTest
    {
        [Test]
        public void AddInfrastructureLayer_ShouldNotThrowException()
        {
            //arrange
            var services = new ServiceCollection();
            var configuration = Substitute.For<IConfiguration>();
            
            //act
            Action act = () => services.AddInfrastructureLayer(configuration);
            
            //assert
            act.Should().NotThrow();
        }
    }
}