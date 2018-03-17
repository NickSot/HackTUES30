using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Resources.Controllers
{
    public class ManageController : ResourcesBaseController
    {
        private readonly IResourceManager resourceManager;
        IHostingEnvironment hostingEnvironment;

        public ManageController(IResourceManager resourceManager, IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
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


        public FileResult DownloadResource(string CurrentPath) {
            byte[] fileBytes = System.IO.File.ReadAllBytes(hostingEnvironment.WebRootPath + CurrentPath);

            string[] arr = CurrentPath.Split("/");

            string fileName = arr[arr.Length - 1];

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}
