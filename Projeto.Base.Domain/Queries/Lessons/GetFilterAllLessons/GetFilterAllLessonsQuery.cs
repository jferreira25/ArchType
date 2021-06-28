using MediatR;

namespace Projeto.Base.Domain.Queries.Lessons.GetFilterAllLessons
{
    public class GetFilterAllLessonsQuery : BaseQuery, IRequest<GetFilterAllLessonsQueryResponse>
    {
        public string Name { get; set; }
    }
}
