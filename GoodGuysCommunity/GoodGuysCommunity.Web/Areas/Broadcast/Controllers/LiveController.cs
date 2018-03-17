using System.Threading.Tasks;
using GoodGuysCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Broadcast.Controllers
{
    public class LiveController : BroadcastBaseController
    {
        private readonly IBroadcastService broadcastService;

        public LiveController(IBroadcastService broadcastService)
        {
            this.broadcastService = broadcastService;
        }

        public async Task<IActionResult> Watch(string username)
        {
            var key = await this.broadcastService.GetStreamKeyAsync(username);

            return this.View(model: key);
        }
    }
}
