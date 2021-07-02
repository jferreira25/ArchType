using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Admin.Core;
using Projeto.Base.Infrastructure.Publisher.LessonQueue;

namespace Projeto.Base.Admin.Infrastructure
{
    internal class RegisterPublishers : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<LessonQueuePublisher>();
            services.AddScoped<LessonTopicPublisher>();
        }
    }
}
