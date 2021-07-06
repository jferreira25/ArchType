using Projeto.Base.Domain.Entities;
using Projeto.Base.Domain.Queries.Users.GetAllUsers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Interfaces.Sql
{
    public interface IUserRepository
    {
        Task<Users> GetByUserAsync(string name,string password);
        Task<IEnumerable<Users>> GetAllAsync(GetAllUsersQuery query);
        Task<long> AddAsync(Users user);
        Task<Users> GetByIdAsync(long id);
        Task<bool> DeleteAsync(long id);
        Task<bool> UpdateAsync(Users user);
    }
}
