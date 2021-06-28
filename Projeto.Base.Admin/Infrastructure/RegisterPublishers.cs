using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Infrastructure.Publisher.LessonQueue;

namespace Projeto.Base.Admin.Infrastructure
{
    public static class RegisterPublishers
    {
        public static void InjectPublisher(IServiceCollection services)
        {
            services.AddScoped<LessonQueuePublisher>();
            services.AddScoped<LessonTopicPublisher>();
        }
    }
}
