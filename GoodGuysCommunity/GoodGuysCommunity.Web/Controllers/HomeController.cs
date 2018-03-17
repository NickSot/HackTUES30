using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoodGuysCommunity.Web.Models;
using Microsoft.AspNetCore.Identity;
using GoodGuysCommunity.Web.Areas.Forum.Models;
using GoodGuysCommunity.Services;
using GoodGuysCommunity.Services.Interfaces;

namespace GoodGuysCommunity.Web.Controllers
{
    public class HomeController : Controller
    {
        IPostService postService;

        public HomeController(IPostService postService) {
            this.postService = postService;
        }

        public IActionResult Index()
        {
            
            return this.View();
        }

        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
