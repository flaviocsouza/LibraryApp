using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Notificator;

namespace LibraryApi.Configuration
{
    public static class NotificationInjectionConfiguration
    {
        public static IServiceCollection NotificationInjectionConfig (this IServiceCollection services)
        {
            services.AddScoped<INotificator, Notificator>();

            return services;
        }
    }
}
