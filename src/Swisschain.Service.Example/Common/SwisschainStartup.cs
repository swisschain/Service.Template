using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swisschain.Service.Example.Services;

namespace Swisschain.Service.Example.Common
{
    public class SwisschainStartup
    {
        public SwisschainStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ApplicationInformation.AppName, Version = "v1" });
            });

            services.AddGrpc();

            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            }));

            ConfigureServicesExt(services);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            ConfigureContainerExt(builder);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<MonitoringService>();

                RegisterEndpoints(endpoints);
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            ConfigureExt(app, env);
        }

        protected virtual void ConfigureServicesExt(IServiceCollection services)
        {

        }

        protected virtual void ConfigureExt(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }

        protected virtual void ConfigureContainerExt(ContainerBuilder builder)
        {

        }

        protected virtual void RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {

        }
    }
}