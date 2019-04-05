using System;
using airlineBOOM.Data;
using airlineBOOM.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace airlineBOOM
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
            // Connection string to my databse
            string connection = "Server =.; Database = myDatabase; Trusted_Connection = True; MultipleActiveResultSets = true";

            // Connect to my database
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connection));

            // Inject userManager & loginManager
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Change password policy
            services.Configure<IdentityOptions>(options =>
            {
                // Make weak passwords possible
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            // Alter app cokkie management
            services.ConfigureApplicationCookie(options =>
            {
                // Changes the login path
                options.LoginPath = "/login";

                // Change cookie time out
                options.ExpireTimeSpan = TimeSpan.FromMinutes(1); // Cokkies expire in one minute currently
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
