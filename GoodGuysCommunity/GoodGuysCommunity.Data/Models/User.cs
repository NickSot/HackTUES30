using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GoodGuysCommunity.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string StreamKey { get; set; } = Guid.NewGuid().ToString();

        public bool IsLive { get; set; }

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<Resource> Uploads { get; set; } = new HashSet<Resource>();

        public ICollection<Resource> FavResources { get; set; } = new HashSet<Resource>();
    }
}
