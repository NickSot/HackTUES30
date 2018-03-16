using GoodGuysCommunity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodGuysCommunity.Web.Areas.Forum.Models
{
    public class PostListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime SubmitDate { get; set; }
    }
}
