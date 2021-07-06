using Moq;
using NUnit.Framework;
using Projeto.Base.Domain.Commands.Authentication.CreateToken;
using Projeto.Base.Domain.Interfaces.Cosmos;
using Projeto.Base.Domain.Services.Redis;
using Projeto.Base.Infrastructure.Publisher.LessonQueue;
using Projeto.Base.Tests.Shared.Mock.CommandHandler.Commands.Authentication.CreateToken;
using Projeto.Base.Tests.Shared.Mock.Infrastructure.Database.Sql;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Base.Tests.Unity.Domain.CommandHandler.Authentication.CreateToken
{
    public class CreateTokenCommandHandlerTest
    {
        protected CreateTokenCommandHandler EstablishContext() => new CreateTokenCommandHandler(
               new UsersRepositoryMock().GetDefaultInstance().Object,
               new Mock<LessonQueuePublisher>().Object,
               new Mock<LessonTopicPublisher>().Object,
               new Mock<ITesteRepository>().Object,
               new Mock<RedisWrapper>().Object,
               new Mock<ILogger>().Object
        );

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(Category = "Unity", TestName = "Should return the token successfully")]
        public async Task Should_Return_Token_Successfully()
        {
            var request = CreateTokenCommandMock.GetDefaultInstance();

            var response = await EstablishContext().Handle(request, CancellationToken.None);

            Assert.IsNotNull(response);
        }
    }
}
