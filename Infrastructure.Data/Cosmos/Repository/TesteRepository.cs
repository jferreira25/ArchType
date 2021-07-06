using Projeto.Base.CrossCutting.Configuration;
using Projeto.Base.Domain.Entities.Cosmos;
using Projeto.Base.Domain.Interfaces.Cosmos;

namespace Projeto.Base.Infrastructure.Data.Cosmos.Repository
{
    public class TesteRepository : CosmosBaseRepository<Exemplo>, ITesteRepository
    {

        public override string DatabaseName => AppSettings.Settings.Cosmos.DatabaseName;

        public override string CosmosDBEndpoint => AppSettings.Settings.Cosmos.DbEndpoint;

        public override string CosmosDBKey => AppSettings.Settings.Cosmos.DbKey;
        
    }
}
