using MediatR;

namespace Projeto.Base.Domain.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQuery : BaseQuery, IRequest<GetAllStudentsQueryResponse>
    {
        public string Name { get; set; }
    }
}
