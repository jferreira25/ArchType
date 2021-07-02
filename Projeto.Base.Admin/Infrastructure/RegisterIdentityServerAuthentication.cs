using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Admin.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Projeto.Base.Admin.Infrastructure
{
    public class RegisterIdentityServerAuthentication : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
          
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthorization(GetAuthorizationConfig())
                .AddAuthentication(GetAuthenticationConfig())
                .AddJwtBearer(GetJwtConfig());
        }
        private static Action<AuthorizationOptions> GetAuthorizationConfig()
        {
            return options =>
            {
                options
                    .AddPolicy("AuthorizationPolicy",
                                policy =>
                                {
                                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                                    policy.RequireClaim("scope", "CadastroCepApi.ConsultaCep");
                                });
            };
        }

        private static Action<AuthenticationOptions> GetAuthenticationConfig()
        {
            return options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            };
        }

        private static Action<JwtBearerOptions> GetJwtConfig()
        {
            return jwtBearerOptions =>
            {
                jwtBearerOptions.Authority = "https://qa-wa-segurancaidentityserver4.azurewebsites.net";
                jwtBearerOptions.Audience = "ApiCadastroCep";
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = false,
                    SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                    {
                        return new JwtSecurityToken(token);
                    }
                };
            };
        }
    }
}
