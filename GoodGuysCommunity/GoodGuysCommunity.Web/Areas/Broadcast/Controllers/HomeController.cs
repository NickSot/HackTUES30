using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Web.Areas.Broadcast.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Broadcast.Controllers
{
    public class HomeController : BroadcastBaseController
    {
        private readonly IBroadcastService broadcastService;
        private readonly UserManager<User> userManager;

        public HomeController(IBroadcastService broadcastService, UserManager<User> userManager)
        {
            this.broadcastService = broadcastService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var streamers = await this.userManager.GetUsersInRoleAsync(WebConstants.StreamerRole);
            var model = streamers.AsQueryable().ProjectTo<StreamerListViewModel>().ToArray();
            return this.View(model);
        }

        public async Task<IActionResult> GoLive()
        {
            if (this.User.IsInRole(WebConstants.StreamerRole))
            {
                await this.broadcastService.GoLive(this.User.Identity.Name);

                this.TempData[WebConstants.TempDataSuccessMessageKey] = "You went live";
            }

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> EndStream()
        {
            if (this.User.IsInRole(WebConstants.StreamerRole))
            {
                await this.broadcastService.EndStream(this.User.Identity.Name);

                this.TempData[WebConstants.TempDataSuccessMessageKey] = "You ended the stream";
            }

            return this.RedirectToAction("Index");
        }
    }
}
