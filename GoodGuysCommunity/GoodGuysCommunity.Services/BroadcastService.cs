using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GoodGuysCommunity.Services
{
    public class BroadcastService : IBroadcastService
    {
        private readonly UserManager<User> userManager;

        public BroadcastService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<string> GetStreamKeyAsync(string userName)
        {
            var user = await this.userManager.FindByNameAsync(userName);

            return user?.StreamKey;
        }
    }
}
