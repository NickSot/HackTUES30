using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Broadcast.Controllers
{
    [Area("Broadcast")]
    [Authorize]
    public class BroadcastBaseController : Controller
    {
    }
}
