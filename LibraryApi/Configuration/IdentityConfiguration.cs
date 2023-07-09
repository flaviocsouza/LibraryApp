using LibraryApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LibraryApi.Configuration
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection IdentityConfig(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LibraryConnectionString")));

            services.AddIdentityCore<IdentityUser>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();

            var jwtSettingsSection = configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            services
                .AddAuthentication(auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(auth =>
                {
                    auth.RequireHttpsMetadata = true;
                    auth.SaveToken = true;
                    auth.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience
                    };
                });



            return services;
        }
    }

}
