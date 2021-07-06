using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Projeto.Base.CrossCutting.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Projeto.Base.Admin.Core
{
    public static class TokenValidator
    {
        public static bool Validate(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                if (!(tokenHandler.ReadToken(token) is JwtSecurityToken))
                    return false;

                var jwtBearerOptions = new JwtBearerOptions()
                {
                    Authority = AppSettings.Settings.JwtTokenSettings.Authority,
                    Audience = AppSettings.Settings.JwtTokenSettings.Audience,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false,
                        SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                        {
                            return new JwtSecurityToken(token);
                        }
                    }
                };

                var principal = tokenHandler.ValidateToken(token, jwtBearerOptions.TokenValidationParameters, out var _);
                
                var containsClaim = GetClaim(token, AppSettings.Settings.JwtTokenSettings.ValidateClaimToken);

                return principal != null && containsClaim != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error TokenValidator" + ex);
                return false;
            }
        }
        public static string GetClaim(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
            return stringClaimValue;
        }
    }
}
