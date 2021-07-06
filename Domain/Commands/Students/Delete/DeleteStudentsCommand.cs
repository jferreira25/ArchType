using MediatR;

namespace Projeto.Base.Domain.Commands.Students.Create
{
    public class DeleteStudentsCommand : IRequest
    {
        public DeleteStudentsCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
