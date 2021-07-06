using Projeto.Base.Domain.Dto;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Interfaces.Sql
{
    public interface IStudentsLessonsProcedure
    {
        Task<long> AddAsync(StudentsLessonsDto studentsLessons);
    }
}
