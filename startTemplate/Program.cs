using System;
using System.IO;
using startTemplate.Data;
using startTemplate.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace startTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Create/Seed the database
                Seeds.SeedDatabase(services);

                // Create the roles for the application
                var serviceProvider = services.GetRequiredService<IServiceProvider>();
                var configuration = services.GetRequiredService<IConfiguration>();
                Seeds.CreateRoles(serviceProvider, configuration).Wait();

                AppDbContext context = services.GetRequiredService<AppDbContext>();

                // Only take this into account when working with existing databases
                // context.Database.Migrate();
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                // You can also use the launchSettings.json to set the default port.
                //.UseUrls("http://*:4000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
    }
}
