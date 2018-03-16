using System;
using System.Threading.Tasks;
using GoodGuysCommunity.Data;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Data.Relations;
using GoodGuysCommunity.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodGuysCommunity.Services
{
    public class ResourceManager : IResourceManager
    {
        private readonly ApplicationDbContext db;

        public ResourceManager(ApplicationDbContext db)
        {
            this.db = db;
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
        }
    }
}
