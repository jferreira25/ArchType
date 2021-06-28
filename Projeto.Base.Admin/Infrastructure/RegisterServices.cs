using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Domain.Interfaces.Tools;
using Projeto.Base.Domain.Services.Xlsx;
using Projeto.Base.Domain.Tools;
using Projeto.Base.Infrastructure.Service.ServiceHandler;

namespace Projeto.Base.Admin.Infrastructure
{
    public static  class RegisterServices
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped(typeof(ISheetsService), typeof(SheetsService));
            services.AddScoped(typeof(IJwtTokenGenerator), typeof(JwtTokenGenerator));
        }
    }
}
