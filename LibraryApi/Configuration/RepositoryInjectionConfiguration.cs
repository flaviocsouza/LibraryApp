using LibraryBusiness.Interface.Repository;
using LibraryData.Repository;

namespace LibraryApi.Configuration
{
    public static class RepositoryInjectionConfiguration
    {
        public static IServiceCollection RepositoryInjectionConfig(this IServiceCollection services)
        {

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();

            return services;
        }
    }
}
