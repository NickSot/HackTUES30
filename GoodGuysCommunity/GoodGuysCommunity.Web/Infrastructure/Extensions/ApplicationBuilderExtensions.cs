using System;
using System.Threading.Tasks;
using GoodGuysCommunity.Data;
using GoodGuysCommunity.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
                //var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var dummyuser = await userManager.Users.FirstOrDefaultAsync();

                        if (dummyuser == null)
                        {
                            dummyuser = new User
                            {
                                Email = "pesho@test.com",
                                UserName = "pesho@test.com",
                            };

                            await userManager.CreateAsync(dummyuser, "admin12");
                        }



 						if (!db.ResourceFolders.Any())
                        {
                            var folder = new ResourceFolder() { Name = "Everything", LastModified = DateTime.Now, Path = "/" };
                            db.ResourceFolders.Add(folder);
                        }
                       
                        await db.SaveChangesAsync();
                    })
                    .Wait();
            }

            return app;
        }
    }
}
