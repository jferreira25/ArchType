using MediatR;

namespace Projeto.Base.Domain.Commands.Lessons.Update
{
    public class UpdateLessonsCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
