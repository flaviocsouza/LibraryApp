using LibraryData.LibraryContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryApi.LibraryDbContextBuilder
{
    public class LibraryDbContextBuilder : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LibraryDbContext>();

            var connectionString = configuration.GetConnectionString("LibraryConnectionString");
            builder.UseSqlServer(connectionString);

            return new LibraryDbContext(builder.Options);

        }
    }
}
