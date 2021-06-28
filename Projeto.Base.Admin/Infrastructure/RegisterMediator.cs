using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Domain.Commands.Authentication.CreateToken;
using System.Reflection;

namespace Projeto.Base.Admin.Infrastructure
{
    public static class RegisterMediator
    {
        public static void InjectMediator(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateTokenCommand).GetTypeInfo().Assembly);
        }
    }
}
