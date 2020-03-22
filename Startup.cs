using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using WebApplication.DbContext;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private string GetPatchedConnectionString(ILogger logger)
        {
            var original = Configuration.GetConnectionString("DefaultConnection");
            if (logger != null)
            {
                logger.LogWarning($"original configuration string = {original}");
            }

            var patched = Configuration.GetConnectionString("DefaultConnection").
                Replace("%DB_SERVER%", Environment.GetEnvironmentVariable("DB_SERVER") ?? "db").
                Replace("%DB_PASSWORD%", Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "Nah^Rauko1ach2k");

            if (logger != null)
            {
                logger.LogWarning($"patched configuration string = {patched}");
            }

            return patched;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.
                    WithOrigins("https://deinlaufbursche.de","https://localhost:4200", "http://localhost:4200", "https://localhost:5100").
                    AllowAnyOrigin().
                    AllowAnyHeader().
                    AllowAnyMethod();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddControllersWithViews();
            services.AddEntityFrameworkMySql();


            services.AddDbContext<MariaContext>(options =>
                options.UseMySql(GetPatchedConnectionString(null),
                    mysqlOptions => mysqlOptions.
                        ServerVersion(new Version(10, 5, 0), ServerType.MariaDb).
                        EnableRetryOnFailure()));

            services.AddMvc();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/ClientApp";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auch ein Laufbursche braucht REST", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            GetPatchedConnectionString(logger);
            app.UsePreflightRequestHandler();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auch ein Laufbursche braucht REST");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseCors(MyAllowSpecificOrigins);

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            using (var scope = serviceProvider.CreateScope())
            {
                var mariaContext = scope.ServiceProvider.GetRequiredService<MariaContext>();
                mariaContext.Database.Migrate();
            }
        }
    }
}
