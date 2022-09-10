using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;

namespace TuiMusement.CitiesWeather.Application.UnitTests
{
    public class DependencyInjectionExtensionsTest
    {
        [Test]
        public void AddApplicationLayer_ShouldNotThrowException()
        {
            //arrange
            var services = Substitute.For<IServiceCollection>();
            //act
            Action act = () => services.AddApplicationLayer();
            //assert
            act.Should().NotThrow();
        }
    }
}