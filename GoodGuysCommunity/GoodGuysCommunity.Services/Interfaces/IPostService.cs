using System.Linq;
using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IPostService
    {
        IQueryable<Post> GetAll();
        IQueryable<Post> GetByDate();
        void Add(string Name, string Content, string AuthorId);
        void Update(int Id, Comment Comment);
        void SaveChanges();
        Task<Post> GetByIdAsync(int id);
    }
}
