using System.Collections.Generic;

namespace Projeto.Base.Domain.Queries.Lessons.GetFilterAllLessons
{
    public class GetFilterAllLessonsQueryResponse
    {
        public List<GetLessonsQueryResponseData> Lessons { get; set; }
        public long TotalRows { get; set; }
    }
    public class GetLessonsQueryResponseData
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
