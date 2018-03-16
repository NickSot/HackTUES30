using System;
using System.Linq;
using System.Threading.Tasks;
using GoodGuysCommunity.Data;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Data.Relations;
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
                //db.Database.Migrate();

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

                        if (!db.Users.Any())
                        {
                            db.Posts.Add(new Post() { Name = "Test", Content = "ASJDHGASDGJDS", Author = dummyuser, PostDate = DateTime.Now });
                        }

                        if (!db.ResourceFolders.Any())
                        {
                            var folder = new ResourceFolder() { Name = "Everything", LastModified = DateTime.Now, Path = "/" };
                            folder.Resources.Add(new Resource() { Author = dummyuser, Name = "asd", FilePath = "/asd.txt" });
                            var inner = new ResourceFolder()
                            {
                                Name = "Inner",
                                Path = "/Inner",
                                LastModified = DateTime.Now
                            };
                            inner.Resources.Add(new Resource() { Author = dummyuser, Name = "asdd", FilePath = "/inner/asd.txt" });
                            folder.SubFolders.Add(new ResourceFolderChild() { Child = inner });
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
