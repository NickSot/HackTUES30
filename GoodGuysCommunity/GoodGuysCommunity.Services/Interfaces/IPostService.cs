using System.Linq;
using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IPostService
    {
        IQueryable<Post> GetAll();
    }
}
