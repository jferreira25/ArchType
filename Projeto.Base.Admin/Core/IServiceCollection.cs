using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Projeto.Base.Admin.Core
{
    public interface IServiceRegistration
    {
        void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
    }
}
