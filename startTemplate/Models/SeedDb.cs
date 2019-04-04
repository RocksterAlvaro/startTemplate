using startTemplate.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace startTemplate.Models
{
    public class Seeds
    {
        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {

                // Look for any data
                if (!context.Database.EnsureCreated())
                {
                    // Debug message
                    string message = "\n Ya hay una base de datos creada. \n";
                    Console.WriteLine(message);

                    return;   // DB has been seeded
                }
                else
                {
                    // Debug message
                    string message = "\n Se ha creado una nueva base de datos. \n";
                    Console.WriteLine(message);

                    // Create a data sample
                    context.Users.Add(
                    new AppUser
                    {
                        UserName = "Pepo",
                        Email = "pepo@gmail.com"
                    }
                );
                    // Save the data samples
                    context.SaveChanges();
                    return;
                }
            }
        }

        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)

        {
            //adding customs roles

            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var UserManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            // Roles in the project
            string[] roleNames = { "Pilot", "Office", "FlightOperator" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)

            {

                // creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);

                if (!roleExist)

                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }

            }
        }
    }
}
