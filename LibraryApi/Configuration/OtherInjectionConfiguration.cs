using LibraryApi.Extensions;
using LibraryBusiness.Interface.Parameters;
using LibraryBusiness.Interface.Request;
using LibraryBusiness.Parameters;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LibraryApi.Configuration
{
    public static class OtherInjectionConfiguration
    {
        public static IServiceCollection OtherInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<ILoanParameters, LoanParameters>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AppUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigOptions>();

            return services;
        }
    }
}
