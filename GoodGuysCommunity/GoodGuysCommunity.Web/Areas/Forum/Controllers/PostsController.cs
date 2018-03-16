using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Services;
using GoodGuysCommunity.Data;
using System.Linq;
using GoodGuysCommunity.Web.Areas.Forum.Models;
using System.Collections.Generic;

namespace GoodGuysCommunity.Web.Areas.Forum.Controllers
{
    public class PostsController : ForumBaseController
    {
        private IPostService postsService;

        public PostsController(IPostService posts)
        {
            this.postsService = posts;
        }
        
        public IActionResult Index()
        {
            var model = this.postsService.GetAll().Select(p => new PostListViewModel()
            {
                Id = p.Id,
                Name = p.Name
            });


            return View(model);
        }
    }
}
