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

        public Comment Add(string Content, int CommentId, int PostId) {
            Comment comment = new Comment();
            comment.Content = Content;
            comment.AuthorId = this.db.Users.Find(CommentId).Id;
            comment.PostId = PostId;
            comment.Author = this.db.Users.Find(comment.AuthorId);
            comment.Post = this.db.Posts.Find(PostId);

            this.db.Add(comment);

            return comment;
        }

        public void Update() {
            this.db.SaveChanges();
        }
    }
}
