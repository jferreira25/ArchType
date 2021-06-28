using MediatR;

namespace Projeto.Base.Domain.Queries.Students.GetStudentsById
{
    public class GetStudentsByIdQuery : IRequest<GetStudentsByIdQueryResponse>
    {
        public long Id { get; set; }

        public GetStudentsByIdQuery(long id)
        {
            Id = id;
        }
    }
}
