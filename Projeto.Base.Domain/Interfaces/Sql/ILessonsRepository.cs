using Projeto.Base.Domain.Entities;
using Projeto.Base.Domain.Queries.Lessons.GetFilterAllLessons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Interfaces.Sql
{
    public interface ILessonsRepository
    {
        Task<IEnumerable<Lesson>> GetAllAsync(GetFilterAllLessonsQuery getAllLessonsQuery);
        Task<IEnumerable<Lesson>> GetAllAsync();
        Task<Lesson> GetByNameAsync(string name);
        Task<long> AddAsync(Lesson lesson);
        Task<Lesson> GetByIdAsync(long id);
        Task<bool> DeleteAsync(long id);
        Task<bool> UpdateAsync(Lesson lesson);
    }
}
