using System.Threading.Tasks;
using GoodGuysCommunity.Data;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GoodGuysCommunity.Services
{
    public class BroadcastService : IBroadcastService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<User> userManager;

        public BroadcastService(UserManager<User> userManager, ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<string> GetStreamKeyAsync(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            return user?.StreamKey;
        }

        public async Task GoLive(string username)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(u => u.UserName == username);
            user.IsLive = true;
            await this.db.SaveChangesAsync();
        }

        public async Task EndStream(string username)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(u => u.UserName == username);
            user.IsLive = false;
            await this.db.SaveChangesAsync();
        }
    }
}
