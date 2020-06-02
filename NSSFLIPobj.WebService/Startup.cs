using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSSFLIPobj.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using NSSFLIPobj.ApplicationServices.GetDistrictListUseCase;
using NSSFLIPobj.ApplicationServices.Ports.Gateways.Database;
using NSSFLIPobj.ApplicationServices.Repositories;
using NSSFLIPobj.DomainObjects.Ports;

namespace NSSFLIPobj.WebService
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
            services.AddDbContext<NSSFLIPobjContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "NSSFLIPobj.db")}")
            );

            services.AddScoped<INSSFLIPobjDatabaseGateway, NSSFLIPobjEFSqliteGateway>();

            services.AddScoped<DbNSSFLIPobjRepository>();
            services.AddScoped<IReadOnlyNSSFLIPobjRepository>(x => x.GetRequiredService<DbNSSFLIPobjRepository>());
            services.AddScoped<INSSFLIPobjRepository>(x => x.GetRequiredService<DbNSSFLIPobjRepository>());


            services.AddScoped<IGetNSSFLIPobjListUseCase, GetNSSFLIPobjListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}