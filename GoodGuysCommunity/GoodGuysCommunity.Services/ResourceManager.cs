using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GoodGuysCommunity.Data;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Data.Relations;
using GoodGuysCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace GoodGuysCommunity.Services
{
    public class ResourceManager : IResourceManager
    {
        private readonly ApplicationDbContext db;
        private readonly IHostingEnvironment appEnvironment;

        public ResourceManager(ApplicationDbContext db, IHostingEnvironment appEnvironment)
        {
            this.db = db;
            this.appEnvironment = appEnvironment;
        }

        public async Task<ResourceFolder> GetAsync(string path)
        {
            var root = await this.db
                .ResourceFolders
                .Include(f => f.Resources)
                .Include(f => f.SubFolders)
                .ThenInclude(s => s.Child)
                .FirstOrDefaultAsync(f => f.Path == path);

            return root;
        }

        public async Task AddFolderAsync(string currentPath, string name)
        {
            var folder = new ResourceFolder()
            {
                LastModified = DateTime.Now,
                Name = name,
                Path = currentPath + $"{name}/"
            };


            var parent = await this.db.ResourceFolders.FirstOrDefaultAsync(f => f.Path == currentPath);
            parent.SubFolders.Add(new ResourceFolderChild() { Child = folder });

            await this.db.SaveChangesAsync();
            var resourcesPath = this.appEnvironment.WebRootPath + "/resources";
            Directory.CreateDirectory(resourcesPath + folder.Path);
        }

        public async Task AddResourceAsync(string currentPath, string name, byte[] bytes)
        {
            var resource = new Resource()
            {
                UploadDate = DateTime.Now,
                Name = name,
                FilePath = currentPath + $"{name}"
            };

            var folder = await this.db.ResourceFolders.FirstOrDefaultAsync(f => f.Path == currentPath);
            folder.Resources.Add(resource);

            //string[] pathArr = name.Split("\\");

            var resourcesPath = "/resources" + currentPath + name;

            using (var file = File.Create(this.appEnvironment.WebRootPath + resourcesPath)) 
            {
                await file.WriteAsync(bytes, 0, bytes.Length);
            }

            await this.db.SaveChangesAsync();
        }
    }
}
