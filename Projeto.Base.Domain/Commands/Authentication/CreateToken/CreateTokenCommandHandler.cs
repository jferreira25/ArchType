using MediatR;
using Projeto.Base.CrossCutting.Configuration.Exceptions;
using Projeto.Base.Domain.Interfaces.Cosmos;
using Projeto.Base.Domain.Interfaces.Sql;
using Projeto.Base.Domain.Publishers;
using Projeto.Base.Infrastructure.Publisher.LessonQueue;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Commands.Authentication.CreateToken
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, CreateTokenCommandResponse>
    {

        private readonly IUserRepository _userRepository;
        private LessonQueuePublisher _serviceBusSender;
        private readonly LessonTopicPublisher _lessonTopicPublisher;
        private readonly ITesteRepository _testeRepository;
        public CreateTokenCommandHandler(
           IUserRepository userRepository,
           LessonQueuePublisher serviceBusSender,
           LessonTopicPublisher lessonTopicPublisher,
            ITesteRepository testeRepository
            )
        {
            _userRepository = userRepository;
            _serviceBusSender = serviceBusSender;
            _lessonTopicPublisher = lessonTopicPublisher;
            _testeRepository = testeRepository;
        }

        public async Task<CreateTokenCommandResponse> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            //utilizacao cosmos
            var example = new Entities.Cosmos.Exemplo() { Id = "12345", Name = "junior" };

            await _testeRepository.AddAsync(example, example.Id);

            var getExample = await _testeRepository.GetAsync(example.Id, example.Id);

            // apenas para demonstração de envio na fila
            await _serviceBusSender.PushQueue(new ImportedLesson() { Mensagem = "teste Junior", CorrelationId = new System.Guid() });

            //apenas para demonstração envio de topico
            
            await _lessonTopicPublisher.SendMessage(new ImportedLesson() { Mensagem = "teste Junior", CorrelationId = new System.Guid() });

            var user = await _userRepository.GetByUserAsync(request.Login, request.Password);

            if (user == null)
                throw new ApiHttpCustomException("Unauthorized", System.Net.HttpStatusCode.Unauthorized);

            return new CreateTokenCommandResponse("123");
        }
    }
}
