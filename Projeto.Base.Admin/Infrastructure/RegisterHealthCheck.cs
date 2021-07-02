using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Admin.Core;
using Projeto.Base.CrossCutting.Configuration;

namespace Projeto.Base.Admin.Infrastructure
{
    internal class RegisterHealthCheck : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                        .AddSqlServer(AppSettings.Settings.Sqlconnections.ConnectionString)
                        .AddAzureServiceBusQueue(AppSettings.Settings.ServiceBusSettings.LessonQueueSub.ConnectionString, AppSettings.Settings.ServiceBusSettings.LessonQueueSub.Name);
        }
    }
}
