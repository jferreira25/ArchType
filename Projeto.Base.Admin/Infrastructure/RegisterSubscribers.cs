using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Subscriber.Interfaces;
using Projeto.Base.Subscriber.LessonQueue;
using Projeto.Base.Subscriber.LessonTopicQueue;

namespace Projeto.Base.Admin.Infrastructure
{
    public static class RegisterSubscribers
    {
        public static void InjectSubscriber(IServiceCollection services)
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
