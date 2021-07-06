
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Admin.Core;
using Serilog;
using Serilog.Events;
using System;

namespace Projeto.Base.Admin.Infrastructure
{
    public class RegisterLogger : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            var loggerConfiguration = new LoggerConfiguration().ReadFrom.Configuration(configuration);

            switch (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != EnvironmentName.Development)
            {
                case true: loggerConfiguration.WriteTo.ApplicationInsights(TelemetryConverter.Events, LogEventLevel.Information); break;
                case false: loggerConfiguration.WriteTo.Console(); break;
            }

            Log.Logger = loggerConfiguration.CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}
