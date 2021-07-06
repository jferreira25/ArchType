using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Admin.Core;
using Projeto.Base.CrossCutting.Configuration;
using Projeto.Base.Domain.Services.Redis;
using StackExchange.Redis;

namespace Projeto.Base.Admin.Infrastructure
{
    public class RegisterRedis : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<RedisWrapper>();
            services.AddSingleton(x =>
            ConnectionMultiplexer.Connect(
                AppSettings.Settings.Redis.ConnectionString).GetDatabase());
        }
    }
}
