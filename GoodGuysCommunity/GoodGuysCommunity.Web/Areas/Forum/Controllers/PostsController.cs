using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Services;
using GoodGuysCommunity.Data;
using System.Linq;
using GoodGuysCommunity.Web.Areas.Forum.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Web.Areas.Forum.Controllers
{
    public class PostsController : ForumBaseController
    {
        private readonly IPostService postsService;
        private readonly UserManager<User> userManager;

        public PostsController(IPostService posts, UserManager<User> userManager)
        {
            this.postsService = posts;
            this.userManager = userManager;
        }
        
        public IActionResult Index()
        {
            var model = this.postsService.GetAll().Select(p => new PostListViewModel()
            {
                Id = p.Id,
                Name = p.Name
            });

            return this.View(model);
        }

        public IActionResult CreatePost()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostListViewModel model) {
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            this.postsService.Add(model.Name, model.Content, user.Id);
            this.postsService.Update();
            return this.RedirectToAction("Index", "Posts");
        }
    }
}
