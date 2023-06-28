using LibraryBusiness.Interface.Parameters;
using LibraryBusiness.Parameters;

namespace LibraryApi.Configuration
{
    public static class OtherInjectionConfiguration
    {
        public static IServiceCollection OtherInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<ILoanParameters, LoanParameters>();
            return services;
        }
    }
}
