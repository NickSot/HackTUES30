using System.Threading.Tasks;
using GoodGuysCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Broadcast.Controllers
{
    public class LiveController : BroadcastBaseController
    {
        public IActionResult Watch()
        {
            return this.View();
        }
    }
}
