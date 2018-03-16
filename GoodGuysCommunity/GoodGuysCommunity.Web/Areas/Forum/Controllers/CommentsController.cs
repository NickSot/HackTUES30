using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Forum.Controllers
{
    public class CommentsController : ForumBaseController
    {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Content, string AuthorId, int PostId) {


            return RedirectToAction("Details", "Posts");
        }
    }
}
