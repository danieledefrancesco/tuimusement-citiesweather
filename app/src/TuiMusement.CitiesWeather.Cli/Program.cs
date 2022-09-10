using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TuiMusement.CitiesWeather.Cli;

namespace TuiMusement.CitiesWeather.Cli
{
    public class Program
    {
        public static async Task Main()
        {
            await ServicesConfigurationRoot.ServiceProvider.GetRequiredService<ProgramRunner>().Run();
        }
    }
}
