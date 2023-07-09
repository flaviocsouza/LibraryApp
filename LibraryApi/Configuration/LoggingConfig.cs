using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.Formatters;

namespace LibraryApi.Configuration
{
    public static class LoggingConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IKLogger>(provider => Logger.Factory.Get());

            services.AddLogging(logging =>
            {
                logging.AddKissLog(opt =>
                {
                    opt.Formatter = (FormatterArgs args) =>
                    {
                        if (args.Exception == null) return args.DefaultValue;
                        string exeptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);
                        return string.Join(Environment.NewLine,new[] { args.DefaultValue, exeptionStr });
                    };
                });
            });
            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app, IConfigurationRoot configuration)
        {
            app.UseKissLogMiddleware(opt => ConfigureKissLog(opt, configuration));
            return app;
        }

        private static void ConfigureKissLog(IOptionsBuilder options, IConfigurationRoot configuration)
        {
            var loggerConfig = configuration.GetSection("KissLogSettings");
            KissLogConfiguration.Listeners.Add(new RequestLogsApiListener(new Application(loggerConfig.GetValue<string>("OrganizationId"), loggerConfig.GetValue<string>("ApplicationId"))) 
                { 
                    ApiUrl = loggerConfig.GetValue<string>("ApiUrl") 
                });
        }
    }
}
