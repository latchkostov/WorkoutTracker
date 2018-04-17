using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkoutTracker.Infra;

namespace WorkoutTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            var SEED_DATABASE = Environment.GetEnvironmentVariable("SEED_DATABASE");
            if (!String.IsNullOrWhiteSpace(SEED_DATABASE) && SEED_DATABASE.Equals("true", StringComparison.CurrentCultureIgnoreCase))
            {
                SeedDatabase(host);
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
              .Build();

        private static void SeedDatabase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<WorkoutTrackerContext>();

                context.Database.Migrate();

                try
                {
                    context.AddRange(SeedData.ExerciseMuscleGroups);
                    context.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Problem seeding database");
                }
            }
        }
    }
}
