using AutoMapper;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Web.Infrastructure.Mapping;

namespace GoodGuysCommunity.Web.Models.HomeViewModels
{
    public class ResourceListViewModel : IHaveCustomMapping
    {
        public string FilePath { get; set; }

        public string AuthorName { get; set; }

        public string Name { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Resource, ResourceListViewModel>()
                .ForMember(m => m.AuthorName, options => options.MapFrom(r => r.Author.UserName));

        }
    }
}
