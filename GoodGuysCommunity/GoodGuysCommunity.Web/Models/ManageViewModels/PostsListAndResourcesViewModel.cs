using GoodGuysCommunity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodGuysCommunity.Web.Models.ManageViewModels
{
    public class PostsListAndResourcesViewModel
    {
        public List<Post> posts { get; set; }
        public List<Resource> resources { get; set; }
        public List<Resource> favouriteResources { get; set; }
    }
}
