using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TuiMusement.CitiesWeather.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services
                .AddMediatR(typeof(DependencyInjectionExtensions).Assembly)
                .AddAutoMapper(typeof(DependencyInjectionExtensions));
        }
    }
}