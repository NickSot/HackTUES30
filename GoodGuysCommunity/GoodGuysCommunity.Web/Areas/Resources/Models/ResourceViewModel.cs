using System;
using AutoMapper;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Web.Infrastructure.Mapping;

namespace GoodGuysCommunity.Web.Areas.Resources.Models
{
    public class ResourceViewModel : IHaveCustomMapping
    {
        public string Name { get; set; }

        public string FilePath { get; set; }

        public DateTime UploadDate { get; set; }

        public string AuthorName { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Resource, ResourceViewModel>()
                .ForMember(m => m.AuthorName, options => options.MapFrom(r => r.Author.UserName));
        }
    }
}
