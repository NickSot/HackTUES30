using System.Collections.Generic;

namespace GoodGuysCommunity.Web.Models.HomeViewModels
{
    public class PostsListAndResourcesViewModel
    {
        public List<PostListViewModel> Posts { get; set; }
        public List<ResourceListViewModel> Resources { get; set; }
    }
}
