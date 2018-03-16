using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodGuysCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Resources.Controllers
{
    public class ManageController : ResourcesBaseController
    {
        private IResourceManager resourceManager;

        public ManageController(IResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddFolder(string name, string currentPath)
        {
            await this.resourceManager.AddFolderAsync(currentPath, name);

            return this.RedirectToAction("Index", "Browse");
        }
    }
}
