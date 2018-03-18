using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Forum.Controllers
{
    [Area(WebConstants.ForumArea)]
    [Authorize]
    public abstract class ForumBaseController : Controller
    {
        
    }
}
