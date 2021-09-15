using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlafatormService.DataAnnotations;
using PlataformService.Models;

namespace PlataformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);

            }
        }
        public static void SeedData(AppDbContext context, bool isProduction)
        {
            if (isProduction)
            {
                Console.WriteLine("-> Attempting to apply migrations ...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Couldn't apply migration {ex.Message}");
                }
            }

            Console.WriteLine("seeding data...");
            if (!context.Platforms.Any())
            {
                context.Platforms.AddRange(
                    new Platform() { Name = ".NET", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                     );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("we already have data");
            }
        }
    }
}