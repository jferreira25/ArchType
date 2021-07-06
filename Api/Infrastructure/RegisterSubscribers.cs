using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Admin.Core;
using Projeto.Base.Subscriber.Interfaces;
using Projeto.Base.Subscriber.LessonQueue;
using Projeto.Base.Subscriber.LessonTopicQueue;

namespace Projeto.Base.Admin.Infrastructure
{
    internal class RegisterSubscribers : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IServiceBusConsumer), typeof(LessonQueueSubscriber));
            services.AddSingleton(typeof(IServiceBusTopicSubscription), typeof(LessonTopicQueueSubscriber));
            var sp = services.BuildServiceProvider();

            var bus = sp.GetService<IServiceBusConsumer>();
            bus.RegisterOnMessageHandlerAndReceiveMessages().GetAwaiter().GetResult();

            var busSubscription = sp.GetService<IServiceBusTopicSubscription>();
            busSubscription.PrepareFiltersAndHandleMessages().GetAwaiter().GetResult();
        }
    }
}
