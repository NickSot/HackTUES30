using AutoMapper;
using GoodGuysCommunity.Data.Models;
using GoodGuysCommunity.Web.Infrastructure.Mapping;

namespace GoodGuysCommunity.Web.Models.HomeViewModels
{
    public class PostListViewModel : IHaveCustomMapping
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string Name { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Post, PostListViewModel>()
                .ForMember(m => m.AuthorName, options => options.MapFrom(p => p.Author.UserName));

        }
    }
}
