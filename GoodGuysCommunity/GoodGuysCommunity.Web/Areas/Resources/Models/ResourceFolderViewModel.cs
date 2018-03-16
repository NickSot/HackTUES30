using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Web.Infrastructure.Mapping;

namespace GoodGuysCommunity.Web.Areas.Resources.Models
{
    public class ResourceFolderViewModel : IHaveCustomMapping
    {
        public string Name { get; set; }

        public DateTime LastModified { get; set; }

        public string Path { get; set; }
        
        public ICollection<ResourceFolderViewModel> Children { get; set; }

        public ICollection<ResourceViewModel> Resources { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<ResourceFolder, ResourceFolderViewModel>()
                .ForMember(m => m.Children, options => options.MapFrom(rf => rf.SubFolders.Select(sf => sf.Child)));
                //.ForMember(m => m.Resources, options => options.MapFrom(rf => rf.Resources));
        }
    }
}
