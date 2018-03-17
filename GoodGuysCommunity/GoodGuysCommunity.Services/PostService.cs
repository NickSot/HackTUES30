using GoodGuysCommunity.Data;
using GoodGuysCommunity.Services.Interfaces;
using System.Linq;
using GoodGuysCommunity.Data.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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

        public IQueryable<Post> GetByDate() {
            IQueryable<Post> posts = this.db.Posts.Include(p => p.Author).OrderBy(p => p.PostDate).Take(4);

            return posts;
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
            var post = this.db.Posts.Find(Id);

            post.Comments.Add(Comment);
        }

        public void SaveChanges() {
            this.db.SaveChanges();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await this.db.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);

            return post;
        }
    }
}
