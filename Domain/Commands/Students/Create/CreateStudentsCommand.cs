using MediatR;

namespace Projeto.Base.Domain.Commands.Students.Create
{
    public class CreateStudentsCommand: IRequest<CreateStudentsCommandResponse>
    {
        public string Name { get; set; }
        public string SchoolGrades { get; set; }
        public long LessonId { get; set; }

    }
}
