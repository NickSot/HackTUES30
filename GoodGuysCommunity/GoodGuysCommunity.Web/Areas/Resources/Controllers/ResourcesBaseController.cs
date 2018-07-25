using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Resources.Controllers
{
    [Area(WebConstants.ResourcesArea)]
    [Authorize]
    public abstract class ResourcesBaseController : Controller
    {
    }
}
