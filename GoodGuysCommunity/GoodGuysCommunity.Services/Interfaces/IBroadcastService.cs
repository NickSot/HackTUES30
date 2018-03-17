using System.Threading.Tasks;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IBroadcastService
    {
        Task<string> GetStreamKeyAsync(string userName);
    }
}
