using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Web.Models;
using Microsoft.AspNetCore.Identity;
using GoodGuysCommunity.Web.Areas.Forum.Models;
using GoodGuysCommunity.Services;
using GoodGuysCommunity.Services.Interfaces;
using System.Linq;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Web.Models.ManageViewModels;

namespace GoodGuysCommunity.Web.Controllers
{
    public class HomeController : Controller
    {
        IPostService postService;

        public HomeController(IPostService postService) {
            this.postService = postService;
        }

        public IActionResult Index(PostsListViewModel model)
        {
            model.posts = this.postService.GetByDate().ToList();
            return this.View(model);
        }

        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
