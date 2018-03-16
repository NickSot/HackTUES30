using GoodGuysCommunity.Data;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodGuysCommunity.Services
{
    public class CommentService: ICommentService
    {
        private ApplicationDbContext db;

        public CommentService(ApplicationDbContext db) {
            this.db = db;
        }

        public void Add(string Content, string AuthorId, int PostId) {
            this.db.Add(new Comment({
                Content = Content,
                AuthorId = AuthorId,
                PostId = PostId
            }));
        }

        public void Update() {
            this.db.SaveChanges();
        }
    }
}
