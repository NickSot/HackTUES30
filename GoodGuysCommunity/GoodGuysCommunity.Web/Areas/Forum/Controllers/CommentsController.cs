using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Services;
using GoodGuysCommunity.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using GoodGuysCommunity.Web.Areas.Forum.Models;

namespace GoodGuysCommunity.Web.Areas.Forum.Controllers
{
    public class CommentsController : ForumBaseController
    {
        private ICommentService commentService;
        private IPostService postService;
        private UserManager<User> userManager;

        public CommentsController(ICommentService commentService, IPostService postService, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.commentService = commentService;
            this.postService = postService;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Content, string Username, int PostId) {
            var user = await userManager.FindByNameAsync(Username);
            
            
            var comment = this.commentService.Add(Content, user.Id, PostId);
            this.commentService.Update();

            this.postService.Update(PostId, comment);
            this.postService.SaveChanges();

            return RedirectToAction("Details", "Posts");
        }
    }
}
