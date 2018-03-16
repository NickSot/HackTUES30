using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Resources.Controllers
{
    public class BrowseController : ResourcesBaseController
    {
        public IActionResult Index()
        {
            //var resources
            return this.View();
        }
    }
}
