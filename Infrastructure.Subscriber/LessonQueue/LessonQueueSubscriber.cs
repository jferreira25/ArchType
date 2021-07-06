using AutoMapper;
using Azure.Messaging.ServiceBus;
using MediatR;
using Projeto.Base.CrossCutting.Configuration;
using Projeto.Base.Domain.Commands.Lessons.Listen;
using Projeto.Base.Domain.Subscribers;
using System;
using System.Threading.Tasks;

namespace Projeto.Base.Subscriber.LessonQueue
{
    public class LessonQueueSubscriber : Subscriber<ImportedLesson>
    {

        public override string TopicName => AppSettings.Settings.ServiceBusSettings.LessonQueueSub.Name;
        public override string ConnectionId => AppSettings.Settings.ServiceBusSettings.LessonQueueSub.ConnectionString;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public LessonQueueSubscriber(
            IMediator mediator,
            IMapper mapper
            ) :base(
            new ServiceBusProcessorOptions
            {
                MaxConcurrentCalls = AppSettings.Settings.ServiceBusSettings.LessonQueueSub.MaxConcurrentCalls,
                AutoCompleteMessages = AppSettings.Settings.ServiceBusSettings.LessonQueueSub.AutoComplete,
            })
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task ConsumeAsync(ImportedLesson importedLesson)
        {
            var listenLessonCommand = _mapper.Map<ListenLessonCommand>(importedLesson);
           
            await _mediator.Send(listenLessonCommand);
        }
    }
}
