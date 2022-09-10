using System;
using TechTalk.SpecFlow;

namespace TuiMusement.CitiesWeather.Specs.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void ResetTestData()
        {
            TestData.Reset();
        }
        
    }
}