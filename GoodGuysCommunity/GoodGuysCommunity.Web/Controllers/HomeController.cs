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
        IResourceManager resourceManager;

        public HomeController(IPostService postService, IResourceManager resourceManager) {
            this.postService = postService;
            this.resourceManager = resourceManager;
        }

        public IActionResult Index(PostsListAndResourcesViewModel model)
        {
            model.posts = this.postService.GetByDate().ToList();
            model.resources = this.resourceManager.GetByDate().ToList();
            return this.View(model);
        }

        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
