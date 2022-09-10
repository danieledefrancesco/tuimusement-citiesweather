using System.Collections.Generic;

namespace TuiMusement.CitiesWeather.Specs
{
    public static class TestData
    {
        public static IEnumerable<string> Lines { get; set; }
        public static void Reset()
        {
            Lines = null;
        }
    }
}