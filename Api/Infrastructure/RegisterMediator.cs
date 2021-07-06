using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Admin.Core;
using Projeto.Base.Domain.Commands.Authentication.CreateToken;
using System.Reflection;

namespace Projeto.Base.Admin.Infrastructure
{
    internal class RegisterMediator : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(CreateTokenCommand).GetTypeInfo().Assembly);
        }
    }
}
