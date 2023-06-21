using LibraryBusiness.Interface.Service;
using LibraryBusiness.Service;

namespace LibraryApi.Configuration
{
    public static class ServiceInjectionConfiguration
    {
        public static IServiceCollection ServiceInjectionConfig( this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILibraryService, LibraryService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IPublisherService, PublisherService>();

            return services;
        }
    }
}
