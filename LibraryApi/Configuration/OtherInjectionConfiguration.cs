using LibraryApi.Extensions;
using LibraryBusiness.Interface.Parameters;
using LibraryBusiness.Interface.Request;
using LibraryBusiness.Parameters;

namespace LibraryApi.Configuration
{
    public static class OtherInjectionConfiguration
    {
        public static IServiceCollection OtherInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<ILoanParameters, LoanParameters>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AppUser>();

            return services;
        }
    }
}
