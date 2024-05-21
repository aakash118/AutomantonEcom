namespace Ordering.API
{
    public static  class DependencyInjection
    {
        public static IServiceCollection InjectAPIServices(this IServiceCollection services)
        {

            return services;
        }
        public static WebApplication UseAPIServices(this WebApplication webApplication)
        {

            return webApplication;
        }
    }
}
