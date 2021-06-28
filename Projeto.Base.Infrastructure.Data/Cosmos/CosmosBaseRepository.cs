using Microsoft.Azure.Cosmos;
using Projeto.Base.Domain.Interfaces.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Base.Infrastructure.Data.Cosmos
{
    public abstract class CosmosBaseRepository<T> : ICosmosDbRepository<T>
    {
        abstract public string DatabaseName { get; }
        abstract public string CosmosDBEndpoint { get; }
        abstract public string CosmosDBKey { get; }

        private Container _container;

        public CosmosBaseRepository()
        {
            var options = new CosmosClientOptions()
            {
                SerializerOptions = new CosmosSerializationOptions()
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                }
            };

            CosmosClient client = new CosmosClient(CosmosDBEndpoint, CosmosDBKey, options);
            var cosmosDbNameClient = typeof(T).Name.ToLower();
      
            _container = client.GetContainer(DatabaseName, cosmosDbNameClient);
        }

        public async Task AddAsync(T item,string partitionKey)
        {
            await _container.CreateItemAsync<T>(item, new PartitionKey(partitionKey));
        }

        public async Task DeleteAsync(string id, string partitionKey)
        {
            await _container.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
        }

        public async Task<T> GetAsync(string id, string partitionKey)
        {
            ItemResponse<T> response = await _container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
            return response.Resource;
        }

        public async Task<IEnumerable<T>> GetAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateAsync(string partitionKey, T item)
        {
            await _container.UpsertItemAsync<T>(item, new PartitionKey(partitionKey));
        }
    }
}
