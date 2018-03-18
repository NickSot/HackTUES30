using System.Threading.Tasks;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IBroadcastService
    {
        Task<string> GetStreamKeyAsync(string username);
        Task GoLive(string username);
        Task EndStream(string username);
    }
}
