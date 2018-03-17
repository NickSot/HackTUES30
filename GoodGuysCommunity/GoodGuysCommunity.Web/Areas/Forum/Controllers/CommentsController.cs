using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Services;
using GoodGuysCommunity.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using GoodGuysCommunity.Web.Areas.Forum.Models;
using System.Linq;

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

            return this.RedirectToAction("Details", "Posts", new { Id = postId });
        }
    }
}
