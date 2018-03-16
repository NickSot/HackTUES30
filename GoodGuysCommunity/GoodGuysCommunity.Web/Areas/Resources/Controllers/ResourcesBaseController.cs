using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Resources.Controllers
{
    [Area("Resources")]
    [Authorize]
    public abstract class ResourcesBaseController : Controller
    {
    }
}
