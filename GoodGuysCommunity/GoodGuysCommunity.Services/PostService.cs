using GoodGuysCommunity.Data;
using GoodGuysCommunity.Services.Interfaces;
using System.Linq;
using GoodGuysCommunity.Data.Models;
using System;

namespace GoodGuysCommunity.Services
{
    public class PostService: IPostService
    {
        private readonly ApplicationDbContext db;

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
                AuthorId = AuthorId,
                PostDate = DateTime.Now
                
            });
        }

        public void Update(int Id, Comment Comment) {
            Post post = this.db.Posts.Find(Id);

            post.Comments.Add(Comment);
        }

        public void SaveChanges() {
            this.db.SaveChanges();
        }

    }
}
