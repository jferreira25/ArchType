using Projeto.Base.Domain.Entities.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Base.Domain.Interfaces.Cosmos
{
    public interface  ITesteRepository
    {
        Task<IEnumerable<Exemplo>> GetAsync(string query);
        Task<Exemplo> GetAsync(string id, string partitionKey);
        Task AddAsync(Exemplo item, string partitionKey);
        Task UpdateAsync(string partitionKey, Exemplo item);
        Task DeleteAsync(string id, string partitionKey);
    }
}
