using System.Linq;
using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IResourceManager
    {
        //IEnumerable<R> GetResources();
        Task<ResourceFolder> GetAsync(string path);
        Task AddFolderAsync(string currentPath, string name);
        Task AddResourceAsync(string currentPath, string author, string name, byte[] bytes);
        void RemoveResource(string Username, int resourceId);
        IQueryable<Resource> GetByDate();
    }
}
