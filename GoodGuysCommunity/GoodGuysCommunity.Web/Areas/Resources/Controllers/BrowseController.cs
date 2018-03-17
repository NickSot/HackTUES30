using System.Threading.Tasks;
using AutoMapper;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Services.Interfaces;
using GoodGuysCommunity.Web.Areas.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoodGuysCommunity.Web.Areas.Resources.Controllers
{
    public class BrowseController : ResourcesBaseController
    {
        private readonly IResourceManager resourceManager;
        private readonly IMapper mapper;

        public BrowseController(IResourceManager resourceManager, IMapper mapper)
        {
            this.resourceManager = resourceManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string path = "/")
        {
            var folder = await this.resourceManager.GetAsync(path);
            var model = this.mapper.Map<ResourceFolderViewModel>(folder);
            return this.View(model);
        }


    }
}
