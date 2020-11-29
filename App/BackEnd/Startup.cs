 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ExpendituresCalculator
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration injectedConfiguration)
        {
            Configuration = injectedConfiguration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ExpendituresCalculatorDbContext>(options => 
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"])
            );
            services.AddRouting();
            services.AddControllers().AddNewtonsoftJson();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        String[] origins = Configuration["Cors:AllowedHosts"].Split(',');
                        builder.WithOrigins(origins)
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsProduction())
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = new Exceptions.JsonExceptionMiddleware().Invoke
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseCors();
            app.UseRouting();
            app.UseEndpoints(routes =>
                routes.MapDefaultControllerRoute()
            );
        }
    }
}
