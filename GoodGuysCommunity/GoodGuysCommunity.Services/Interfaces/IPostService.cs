using System.Linq;
using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IPostService
    {
        IQueryable<Post> GetAll();
        IQueryable<Post> GetByDate();
        void Add(string name, string content, string authorId);
        void Update(int id, Comment comment);
        Task<Post> GetByIdAsync(int id);
    }
}
