using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Web.Areas.Broadcast.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodGuysCommunity.Web.Areas.Broadcast.Controllers
{
    public class HomeController : BroadcastBaseController
    {
        private readonly IBroadcastService broadcastService;

        public HomeController(IBroadcastService broadcastService)
        {
            this.broadcastService = broadcastService;
        }

        public async Task<IActionResult> Index()
        {
            var streamers = await this.broadcastService.GetLiveStreamers();
            var model = streamers.AsQueryable().ProjectTo<StreamerListViewModel>().ToArray();
            return this.View(model);
        }

        public async Task<IActionResult> GoLive()
        {
            if (this.User.IsInRole("Streamer"))
            {
                await this.broadcastService.GoLive(this.User.Identity.Name);
            }

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> EndStream()
        {
            if (this.User.IsInRole("Streamer"))
            {
                await this.broadcastService.EndStream(this.User.Identity.Name);
            }

            return this.RedirectToAction("Index");
        }
    }
}
