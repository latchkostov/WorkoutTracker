using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WorkoutTracker.Infra;
using WorkoutTracker.Services;

namespace WorkoutTracker
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
            services.AddAutoMapper();

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            var DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (String.IsNullOrWhiteSpace(DATABASE_URL))
                throw new ArgumentException("DATABASE_URL environment variable required for Postgres SQL string.");

            string connectionString = ConvertPostgresUrlToConnectionString(DATABASE_URL);

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<WorkoutTrackerContext>(options => {
                    options.UseNpgsql(connectionString);
                });

            services.AddTransient<IExerciseService, ExerciseService>();
            services.AddTransient<IMuscleGroupService, MuscleGroupService>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

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
        }

        private string ConvertPostgresUrlToConnectionString(string urlString)
        {
            if (Uri.TryCreate(urlString, UriKind.Absolute, out var uri))
            {
                var userInfo = uri.UserInfo.Split(':');
                var connectionString = $"host={uri.Host};username={userInfo[0]};password={userInfo[1]};database={uri.LocalPath.Substring(1)};pooling=true;";
                if (!uri.IsLoopback)
                {
                    connectionString += "SSL Mode=Require;Trust Server Certificate=true;";
                }
                    
                return connectionString;
            }
            else
            {
                throw new ArgumentException("Unable to parse Postgres SQL.", nameof(urlString));
            }
        }
    }
}
