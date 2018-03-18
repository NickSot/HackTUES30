using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Services.Interfaces;
using System.Linq;
using GoodGuysCommunity.Web.Areas.Forum.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;
using System;
using GoodGuysCommunity.Web.Infrastructure.Extensions;

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
            var model = this.postsService.GetAll().Select(p => new PostDetailsViewModel()
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
        public async Task<IActionResult> CreatePost(PostDetailsViewModel model) {
            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            this.postsService.Add(model.Name, model.Content, user.Id);
            this.TempData.AddSuccessMessage("Post added");

            return this.RedirectToAction("Index", "Posts");
        }

        public async Task<IActionResult> Details(int id) {
            var post = await this.postsService.GetByIdAsync(id);

            var model = new PostDetailsViewModel()
            {
                Name = post.Name,
                Content = post.Content,
                Id = post.Id,
                Comments = post.Comments.ToList(),
                SubmitDate = DateTime.Now
            };

            return this.View(model);
        }
    }
}
