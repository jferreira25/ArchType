using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.CrossCutting.Configuration;

namespace Projeto.Base.Admin.Infrastructure
{
    public static class RegisterHealthCheck
    {
        public static void InjectHealth(IServiceCollection services)
        {
            services.AddHealthChecks()
                         .AddSqlServer(AppSettings.Settings.Sqlconnections.ConnectionString)
                         .AddAzureServiceBusQueue(AppSettings.Settings.ServiceBusSettings.LessonQueueSub.ConnectionString, AppSettings.Settings.ServiceBusSettings.LessonQueueSub.Name);
        }
    }
}
