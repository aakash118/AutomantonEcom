using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectApplicationServices(this IServiceCollection services)
        {

            return services;
        }
    }
}
