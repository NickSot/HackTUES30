using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
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
                return this.BadRequest("No username");
            }


            var user = await this.userManager.FindByNameAsync(username);
            if (user == null)
            {
                return this.BadRequest("No existing user");
            }

            if (!await this.userManager.IsInRoleAsync(user, "Streamer"))
            {
                return this.BadRequest("User is not a streamer");
            }

            if (!user.IsLive)
            {
                return this.BadRequest("User not live");
            }

            var key = await this.broadcastService.GetStreamKeyAsync(username);

            return this.View(model: key);
        }
    }
}
