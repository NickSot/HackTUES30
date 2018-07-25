using GoodGuysCommunity.Data.Models;
using System;
using System.Collections.Generic;

namespace GoodGuysCommunity.Web.Areas.Forum.Models
{
    public class PostDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime SubmitDate { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
