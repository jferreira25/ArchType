namespace Projeto.Base.Tests.Shared.Mock.Domain.Entities.Students
{
    public static class StudentsMock
    {
        public static Projeto.Base.Domain.Entities.Students GetDefaultInstance() => new Projeto.Base.Domain.Entities.Students
        {
            Id = 0,
            Name = "Mock"
        };
    }
}
