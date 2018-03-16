using System.Linq;
using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IResourceManager
    {
        //IEnumerable<R> GetResources();
        Task<ResourceFolder> GetAsync(string path);
    }
}
