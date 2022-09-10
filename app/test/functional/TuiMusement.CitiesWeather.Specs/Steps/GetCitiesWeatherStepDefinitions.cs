using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TuiMusement.CitiesWeather.Cli;

namespace TuiMusement.CitiesWeather.Specs.Steps
{
    [Binding]
    public class GetCitiesWeatherStepDefinitions
    {
        [Given(@"the weather forecast for London today is ""(.*)""")]
        public void GivenTheWeatherForecastForLondonTodayIs(string weatherCondition)
        {
            //nothing to do, wiremock has been configured via file system
        }

        [Given(@"the weather forecast for London tomorrow is ""(.*)""")]
        public void GivenTheWeatherForecastForLondonTomorrowIs(string weatherCondition)
        {
            //nothing to do, wiremock has been configured via file system
        }

        [When(@"I execute the program")]
        public async Task WhenIExecuteTheProgram()
        {
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                await Program.Main();

                await Console.Out.FlushAsync();
                await writer.FlushAsync();

                TestData.Lines = writer.GetStringBuilder().ToString().Split(Environment.NewLine);
            }

            Console.SetOut(originalConsoleOut);
        }

        [Then(@"it prints out ""(.*)""")]
        public void ThenItPrintsOut(string line)
        {
            TestData.Lines.Should().Contain(line);
        }
    }
}