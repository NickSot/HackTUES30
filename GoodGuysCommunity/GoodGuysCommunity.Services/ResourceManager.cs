using System.Threading.Tasks;
using GoodGuysCommunity.Data;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodGuysCommunity.Services
{
    public class ResourceManager : IResourceManager
    {
        private ApplicationDbContext db;

        public ResourceManager(ApplicationDbContext db)
        {
            this.db = db;
        }

        // /9a
        public async Task<ResourceFolder> GetAsync(string path)
        {
            var root = await this.db
                .ResourceFolders
                .Include(f => f.Resources)
                .Include(f => f.SubFolders)
                .ThenInclude(s => s.Child)
                .FirstOrDefaultAsync(f => f.Path == path);
            //var subfolders = path.Split("/");

            return root;
        }
    }
}
