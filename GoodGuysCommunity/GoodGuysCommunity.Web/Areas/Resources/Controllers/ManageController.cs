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
        private UserManager<User> users;

        public ManageController(IResourceManager resourceManager, IHostingEnvironment hostingEnvironment, UserManager<User> users)
        {
            this.users = users;
            this.hostingEnvironment = hostingEnvironment;
            this.resourceManager = resourceManager;
            this.hostingEnvironment = hostingEnvironment;
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
            var user = await this.users.FindByNameAsync(this.User.Identity.Name);
            await this.resourceManager.AddResourceAsync(currentPath, user.Id, file.FileName, await file.GetData());

            return this.RedirectToAction("Index", "Browse", new { path = currentPath });
        }


        public FileResult DownloadResource(string currentPath)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(this.hostingEnvironment.WebRootPath + currentPath);

            string[] arr = currentPath.Split("/");

            string fileName = arr[arr.Length - 1];

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public IActionResult RemoveFile(int resourceId)
        {

            this.resourceManager.RemoveResource(this.User.Identity.Name, resourceId);

            return RedirectToAction("Index", "Browse");
        }
    }
}

