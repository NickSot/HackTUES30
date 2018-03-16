using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GoodGuysCommunity.Data
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public ICollection<Post> Posts { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Resource> Uploads { get; set; }
    }
}
