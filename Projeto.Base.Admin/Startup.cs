using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projeto.Base.Admin.Extensions;
using Projeto.Base.Admin.Filter;
using Projeto.Base.Admin.Middlewares;
using Projeto.Base.Domain.Commands.Authentication.CreateToken;
using Projeto.Base.Subscriber.LessonQueue;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Projeto.Base
{
    public class Startup
    {
        public Container DependencyInjectionContainer { get; } = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            DependencyInjectionContainer.Options.DefaultLifestyle = Lifestyle.Scoped;
            DependencyInjectionContainer.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.UseSimpleInjectorAspNetRequestScoping(DependencyInjectionContainer);

            services
                .AddMvc(options => options.Filters.Add(typeof(ApiValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateTokenCommand>());

            services.AddAutoMapper(typeof(LessonQueueSubscriber));

            services.AddServicesInAssembly(Configuration);

            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto base  V1");
            });

            app.UseRouting();

             app.UseAuthenticationMiddleware();
           // app.UseAuthentication();

            //Adds authorization middleware to the pipeline to make sure the Api endpoint cannot be accessed by anonymous clients
           // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapControllers();
            });
        }
    }
}
