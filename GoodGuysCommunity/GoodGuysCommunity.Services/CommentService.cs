using GoodGuysCommunity.Data;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GoodGuysCommunity.Services
{
    public class CommentService: ICommentService
    {
        private ApplicationDbContext db;
        private readonly UserManager<User> userManager;

        public CommentService(ApplicationDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task Add(string Content, string authorname, int PostId)
        {
            var author = await this.userManager.FindByNameAsync(authorname);

            var comment = new Comment
            {
                Content = Content,
                Author = author,
                PostId = PostId
            };

            await this.db.Comments.AddAsync(comment);
            
            await this.db.SaveChangesAsync();
        }
        
    }
}
