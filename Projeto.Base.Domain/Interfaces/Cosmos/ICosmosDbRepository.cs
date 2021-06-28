using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Interfaces.Cosmos
{
    public interface ICosmosDbRepository<T>
    {
        Task<IEnumerable<T>> GetAsync(string query);
        Task<T> GetAsync(string id, string partitionKey);
        Task AddAsync(T item, string partitionKey);
        Task UpdateAsync(string partitionKey, T item);
        Task DeleteAsync(string id, string partitionKey);
    }
}
