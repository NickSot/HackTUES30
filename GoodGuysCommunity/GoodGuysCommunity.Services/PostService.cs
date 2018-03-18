using GoodGuysCommunity.Data;
using GoodGuysCommunity.Services.Interfaces;
using System.Linq;
using GoodGuysCommunity.Data.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            var posts = this.db.Posts.Include(p => p.Author).OrderBy(p => p.PostDate).Take(4);

            return posts;
        }

        public void Add(string name, string content, string authorId) {
            this.db.Add(new Post()
            {
                Name = name,
                Content = content,
                AuthorId = authorId,
                PostDate = DateTime.Now
            });

            this.db.SaveChanges();
        }

        public void Update(int id, Comment comment) {
            var post = this.db.Posts.Find(id);

            post.Comments.Add(comment);
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await this.db.Posts.Include(p => p.Comments).Include(p => p.Author).FirstOrDefaultAsync(p => p.Id == id);

            return post;
        }
    }
}
