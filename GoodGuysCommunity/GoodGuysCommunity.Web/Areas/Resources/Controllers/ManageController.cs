using System.Threading.Tasks;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Resources.Controllers
{
    public class ManageController : ResourcesBaseController
    {
        private readonly IResourceManager resourceManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<User> userManager;

        public ManageController(IResourceManager resourceManager, IHostingEnvironment hostingEnvironment, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
            this.resourceManager = resourceManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddFolder(string name, string currentPath)
        {
            if (name == null)
            {
                this.TempData.AddErrorMessage("You cannot create a folder without a name");
            }
            else
            {
                await this.resourceManager.AddFolderAsync(currentPath, name);
                this.TempData.AddSuccessMessage($"You created the {name} folder");
            }

            return this.RedirectToAction("Index", "Browse", new { path = currentPath });
        }

        [HttpPost]
        public async Task<IActionResult> AddResource(IFormFile file, string currentPath)
        {
            if (file == null)
            {
                this.TempData.AddErrorMessage("You must select a file to upload");
                return this.RedirectToAction("Index", "Browse", new { path = currentPath });
            }

            var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            await this.resourceManager.AddResourceAsync(currentPath, user.Id, file.FileName, await file.GetData());
            this.TempData.AddSuccessMessage($"File {file.FileName} uploaded");

            return this.RedirectToAction("Index", "Browse", new { path = currentPath });
        }


        public FileResult DownloadResource(string currentPath)
        {
            var fileBytes = System.IO.File.ReadAllBytes(this.hostingEnvironment.WebRootPath + currentPath);

            var arr = currentPath.Split("/");

            var fileName = arr[arr.Length - 1];

            return this.File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public IActionResult RemoveFile(int resourceId, string currentPath)
        {
            var deleted = this.resourceManager.RemoveResource(this.User.Identity.Name, resourceId);

            if (deleted)
            {
                this.TempData.AddSuccessMessage($"File deleted");
            }
            else
            {
                this.TempData.AddErrorMessage($"You cannot delete a file that is not yours");
            }
            
            return this.RedirectToAction("Index", "Browse", new { path = currentPath });
        }
    }
}



