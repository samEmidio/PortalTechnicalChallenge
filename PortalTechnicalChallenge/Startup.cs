using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using PortalTechnicalChallenge.Infra.Data;
using PortalTechnicalChallenge.Infra.Data.Context;
using PortalTechnicalChallenge.Infra.CrossCutting.IoC;
using System.Reflection;

/// <summary>
/// statup - configuracoes de swagger - mediat - ninject - cors
/// </summary>

namespace PortalTechnicalChallenge
{
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

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            ConfigureCors(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PortalTechnicalChallenge", Version = "v1" });
            });

            //Debugger.Launch();

            NativeInjectorBootStrapper.RegisterServices(services);
            DatabaseSetup.AddDatabaseSetup(services, Configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();
           



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PortalTechnicalChallengeContext>();
                context.Database.Migrate();
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portal Technical Challenge v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseCors(option => {
                option.AllowAnyOrigin();
                option.AllowAnyHeader();
                option.AllowAnyMethod();
                option.AllowAnyOrigin();
                });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        public void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsMiddleware", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .Build());
            });
        }

    }
}
