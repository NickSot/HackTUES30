using GoodGuysCommunity.Data;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GoodGuysCommunity.Services
{
    public class CommentService: ICommentService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<User> userManager;

        public CommentService(ApplicationDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task Add(string content, string authorname, int postId)
        {
            var author = await this.userManager.FindByNameAsync(authorname);

            var comment = new Comment
            {
                Content = content,
                Author = author,
                PostId = postId
            };

            await this.db.Comments.AddAsync(comment);
            
            await this.db.SaveChangesAsync();
        }
        
    }
}
