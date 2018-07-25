using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Web.Infrastructure.Mapping;

namespace GoodGuysCommunity.Web.Areas.Broadcast.Models
{
    public class StreamerListViewModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public bool IsLive { get; set; }
    }
}
