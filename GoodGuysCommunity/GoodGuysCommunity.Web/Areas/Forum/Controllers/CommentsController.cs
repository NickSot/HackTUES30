using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Services.Interfaces;
using System.Threading.Tasks;
using GoodGuysCommunity.Web.Infrastructure.Extensions;

namespace GoodGuysCommunity.Web.Areas.Forum.Controllers
{
    public class CommentsController : ForumBaseController
    {
        private ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(string content, string username, int postId)
        {
            await this.commentService.Add(content, username, postId);
            
            this.TempData.AddSuccessMessage("Comment added");

            return this.RedirectToAction("Details", "Posts", new { Id = postId });
        }
    }
}
