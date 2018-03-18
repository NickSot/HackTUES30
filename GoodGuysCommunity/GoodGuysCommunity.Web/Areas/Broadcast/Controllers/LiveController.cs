using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Broadcast.Controllers
{
    public class LiveController : BroadcastBaseController
    {
        private readonly IBroadcastService broadcastService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public LiveController(IBroadcastService broadcastService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.broadcastService = broadcastService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Watch(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                this.TempData.AddErrorMessage("No username given");
                return this.RedirectToAction("Index", "Home");
            }


            var user = await this.userManager.FindByNameAsync(username);
            if (user == null)
            {
                this.TempData.AddErrorMessage("User does not exist");
                return this.RedirectToAction("Index", "Home");
            }

            if (!await this.userManager.IsInRoleAsync(user, WebConstants.StreamerRole))
            {
                this.TempData.AddErrorMessage("User is not a streamer");
                return this.RedirectToAction("Index", "Home");
            }

            if (!user.IsLive)
            {
                this.TempData.AddErrorMessage("User is offline");
                return this.RedirectToAction("Index", "Home");
            }

            var key = await this.broadcastService.GetStreamKeyAsync(username);

            return this.View(model: key);
        }
    }
}
