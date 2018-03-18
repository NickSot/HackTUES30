using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Web.Models;
using GoodGuysCommunity.Services.Interfaces;
using System.Linq;
using AutoMapper.QueryableExtensions;
using GoodGuysCommunity.Web.Models.HomeViewModels;
using GoodGuysCommunity.Web.Models.ManageViewModels;

namespace GoodGuysCommunity.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        private readonly IResourceManager resourceManager;

        public HomeController(IPostService postService, IResourceManager resourceManager) {
            this.postService = postService;
            this.resourceManager = resourceManager;
        }

        public IActionResult Index()
        {
            var model = new PostsListAndResourcesViewModel
            {
                Posts = this.postService.GetByDate().ProjectTo<PostListViewModel>().ToList(),
                Resources = this.resourceManager.GetByDate().ProjectTo<ResourceListViewModel>().ToList()
            };
            return this.View(model);
        }

        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
