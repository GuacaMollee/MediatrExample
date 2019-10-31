namespace Example.Ordering.Api
{
    using System;
    using System.Reflection;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Example.Ordering.Api.Repositories;
    using Example.Ordering.Domain.Pipeline;
    using FluentValidation;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            const string domainLayerAssemblyName = "Example.Ordering.Domain";
            //const string infrastructureLayerAssemblyName = "Example.Ordering.Infrastructure";
            var domainLayerAssembly = AppDomain.CurrentDomain.Load(domainLayerAssemblyName);
            //var infrastructureLayerAssembly = AppDomain.CurrentDomain.Load(infrastructureLayerAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(domainLayerAssembly)
                .ForEach(result => services.AddTransient(result.InterfaceType, result.ValidatorType));

            services.AddControllers();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterGeneric(typeof(DefaultPipelineBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediatrExample");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
