using System.Threading.Tasks;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Resources.Controllers
{
    public class ManageController : ResourcesBaseController
    {
        private readonly IResourceManager resourceManager;

        public ManageController(IResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddFolder(string name, string currentPath)
        {
            await this.resourceManager.AddFolderAsync(currentPath, name);

            return this.RedirectToAction("Index", "Browse", new { path = currentPath });
        }

        [HttpPost]
        public async Task<IActionResult> AddResource(IFormFile file, string currentPath)
        {
            await this.resourceManager.AddResourceAsync(currentPath, file.FileName, await file.GetData());

            return this.RedirectToAction("Index", "Browse", new { path = currentPath });
        }
    }
}
