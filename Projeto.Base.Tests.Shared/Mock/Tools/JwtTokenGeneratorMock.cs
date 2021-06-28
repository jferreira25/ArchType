using Moq;
using Projeto.Base.Domain.Interfaces.Tools;
using Projeto.Base.Tests.Shared.Core;

namespace Projeto.Base.Tests.Shared.Mock.Tools
{
    public class JwtTokenGeneratorMock : BaseMock<IJwtTokenGenerator>
    {
        public override Mock<IJwtTokenGenerator> GetDefaultInstance()
        {
            JwtService();
            return Mock;
        }

        private void JwtService()
        {
            Setup(r => r.GenerateToken(It.IsAny<string>()), "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9hdXRoZW50aWNhdGlvbiI6Ijc2NTU4OTY4LWJhZjQtNGFjNi04MzA4LTQ3Mzk4OTIwNzBlNV9UZXN0ZSIsIm5iZiI6MTYwODE1NTQ1OCwiZXhwIjoxNjA4MTU2MzU4LCJpc3MiOiJBbGVydHMifQ.P5UiI-vFKi5m7mB6VAVksPMFWR3lRDgTM-wjapNQDH0");
        }
    }
}
