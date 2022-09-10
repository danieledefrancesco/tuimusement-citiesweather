using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;

namespace TuiMusement.CitiesWeather.Cli.UnitTests
{
    public class ServicesConfigurationRootTest
    {
        [Test]
        public void BuildServiceProvider_ShouldNotThrowException()
        {
            //act
            Action act = () => ServicesConfigurationRoot.BuildServiceProvider();
            
            //assert
            act.Should().NotThrow();
        }
    }
}