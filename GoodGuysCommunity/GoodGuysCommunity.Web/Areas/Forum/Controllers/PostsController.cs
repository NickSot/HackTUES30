using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Services;
using GoodGuysCommunity.Data;
using System.Linq;
using GoodGuysCommunity.Web.Areas.Forum.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GoodGuysCommunity.Web.Areas.Forum.Controllers
{
    public class PostsController : ForumBaseController
    {
        private IPostService postsService;
        private UserManager<User> userManager;

        public PostsController(IPostService posts, UserManager<User> UserManager)
        {
            this.postsService = posts;
            this.userManager = UserManager;
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

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostListViewModel model) {
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            this.postsService.Add(model.Name, model.Content, user.Id);
            this.postsService.Update();
            return RedirectToAction("Index", "Posts");
        }
    }
}
