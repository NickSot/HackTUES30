using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IBroadcastService
    {
        Task<string> GetStreamKeyAsync(string username);
        Task<IEnumerable<User>> GetLiveStreamers();
        Task GoLive(string username);
        Task EndStream(string username);
    }
}
