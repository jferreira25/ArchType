using AutoMapper;
using Azure.Messaging.ServiceBus;
using MediatR;
using Projeto.Base.CrossCutting.Configuration;
using Projeto.Base.Domain.Commands.Lessons.Listen;
using System.Threading.Tasks;
using ImportedLesson = Projeto.Base.Domain.Subscribers.ImportedLesson;

namespace Projeto.Base.Subscriber.LessonTopicQueue
{
    public class LessonTopicQueueSubscriber : TopicSubscriber<ImportedLesson>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public LessonTopicQueueSubscriber(
            IMediator mediator,
            IMapper mapper)
            : base(new ServiceBusProcessorOptions
            {
                MaxConcurrentCalls = AppSettings.Settings.ServiceBusSettings.LessonTopicQueueSub.MaxConcurrentCalls,
                AutoCompleteMessages = AppSettings.Settings.ServiceBusSettings.LessonTopicQueueSub.AutoComplete,
            })
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override string TopicName => AppSettings.Settings.ServiceBusSettings.LessonTopicQueueSub.TopicName;

        public override string Name => AppSettings.Settings.ServiceBusSettings.LessonTopicQueueSub.Name;

        public override string ConnectionId => AppSettings.Settings.ServiceBusSettings.LessonTopicQueueSub.ConnectionString;

        public override async Task ConsumeAsync(ImportedLesson importedLesson)
        {
            var listenLessonCommand = _mapper.Map<ListenLessonCommand>(importedLesson);

            await _mediator.Send(listenLessonCommand);
        }

    }
}
