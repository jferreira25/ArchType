using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Projeto.Base.Admin.Filter;
using System.Collections.Generic;

namespace Projeto.Base.Admin.Infrastructure
{
    public static class RegisterSwagger
    {
        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example \"Authorization: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"

                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                         new OpenApiSecurityScheme
                         {
                             Reference = new OpenApiReference {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer" }
                         }, new List<string>() }
                });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Projeto base API",
                    Description = "Api para avaliação conectcar"
                });
                c.OperationFilter<SwaggerOperationFilter>();
            });
        }
    }
}
