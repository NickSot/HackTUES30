using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Forum.Controllers
{
    public class CommentsController : ForumBaseController
    {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public void Index(string Content) {

        }
    }
}
