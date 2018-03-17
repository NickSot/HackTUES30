using System.Linq;
using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IPostService
    {
        IQueryable<Post> GetAll();
        void Add(string Name, string Content, string AuthorId);
        void Update(int Id, Comment Comment);
        void SaveChanges();
    }
}
