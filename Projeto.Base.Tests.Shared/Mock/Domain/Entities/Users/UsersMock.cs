namespace Projeto.Base.Tests.Shared.Mock.Domain.Entities.Users
{
    public static class UsersMock
    {
        public static Base.Domain.Entities.Users GetDefaultInstance() => new Base.Domain.Entities.Users
        {
            Id = 0,
            Name = "candidato-evolucional",
            Password = "1234"
           
        };
    }
}
