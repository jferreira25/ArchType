using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Admin.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using Projeto.Base.CrossCutting.Configuration;

namespace Projeto.Base.Admin.Infrastructure
{
    public class RegisterIdentityServerAuthentication : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
          
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthorization()
                .AddAuthentication(GetAuthenticationConfig())
                .AddJwtBearer(GetJwtConfig());
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
                jwtBearerOptions.Authority = AppSettings.Settings.JwtTokenSettings.Authority;
                jwtBearerOptions.Audience = AppSettings.Settings.JwtTokenSettings.Audience;
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
