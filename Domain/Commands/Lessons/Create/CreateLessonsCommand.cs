using MediatR;

namespace Projeto.Base.Domain.Commands.Lessons.Create
{
    public class CreateLessonsCommand : IRequest<CreateLesonsCommandResponse>
    {
        public string Name { get; set; }
     
    }
}
