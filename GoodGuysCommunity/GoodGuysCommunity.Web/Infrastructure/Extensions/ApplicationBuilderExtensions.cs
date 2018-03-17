using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GoodGuysCommunity.Data;
using GoodGuysCommunity.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GoodGuysCommunity.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                db.Database.Migrate();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var dummyuser = await userManager.Users.FirstOrDefaultAsync();

                        if (dummyuser == null)
                        {
                            dummyuser = new User
                            {
                                Email = "test@test.com",
                                UserName = "Test"
                            };

                            await userManager.CreateAsync(dummyuser, "test12");
                        }
                        
 						if (!db.ResourceFolders.Any())
                        {
                            var folder = new ResourceFolder() { Name = "Everything", LastModified = DateTime.Now, Path = "/" };
                            db.ResourceFolders.Add(folder);
                        }

                        if (!roleManager.Roles.Any())
                        {
                            var streamer = new IdentityRole("Streamer");
                            var admin = new IdentityRole("Admin");
                            await roleManager.CreateAsync(streamer);
                            await roleManager.CreateAsync(admin);
                            await userManager.AddToRoleAsync(dummyuser, "Streamer");
                        }
                       
                        await db.SaveChangesAsync();
                    })
                    .Wait();
            }

            return app;
        }
    }
}
