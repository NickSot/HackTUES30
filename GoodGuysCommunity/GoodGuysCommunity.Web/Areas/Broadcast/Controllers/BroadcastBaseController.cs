using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Broadcast.Controllers
{
    [Area(WebConstants.BroadcastArea)]
    [Authorize]
    public class BroadcastBaseController : Controller
    {
    }
}
