using GoodGuysCommunity.Data;
using GoodGuysCommunity.Services.Interfaces;
using System.Linq;
using GoodGuysCommunity.Data.Models;


namespace GoodGuysCommunity.Services
{
    public class PostService: IPostService
    {
        private ApplicationDbContext db;

        public PostService(ApplicationDbContext db) {
            this.db = db;
        }

        public IQueryable<Post> GetAll()
        {
            return this.db.Posts.AsQueryable();
        }

        public void Add(string Name, string Content, string AuthorId) {
            this.db.Add(new Post()
            {
                Name = Name,
                Content = Content,
                AuthorId = AuthorId
                
            });
        }

        public void Update() {
            this.db.SaveChanges();
        }

    }
}
