using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Services;
using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Web.Areas.Forum.Controllers
{
    public class CommentsController : ForumBaseController
    {
        public ICommentService commentService;
        public IPostService postService;

        public CommentsController(ICommentService commentService, IPostService postService)
        {
            this.commentService = commentService;
            this.postService = postService;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Content, int Id, int PostId) {
            

            var comment = this.commentService.Add(Content, Id, PostId);
            this.commentService.Update();

            this.postService.Update(PostId, comment);
            this.postService.SaveChanges();

            return RedirectToAction("Details", "Posts");
        }
    }
}
