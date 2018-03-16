﻿using GoodGuysCommunity.Data;
using GoodGuysCommunity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
    }
}
