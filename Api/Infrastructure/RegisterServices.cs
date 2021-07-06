using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Admin.Core;
using Projeto.Base.Domain.Services.Xlsx;
using Projeto.Base.Infrastructure.Service.ServiceHandler;

namespace Projeto.Base.Admin.Infrastructure
{
    internal class RegisterServices : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(ISheetsService), typeof(SheetsService));
        }
    }
}
