using System;
using System.Collections.Generic;
using GoodGuysCommunity.Data.Relations;

namespace GoodGuysCommunity.Data.Models
{
    public class ResourceFolder
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime LastModified { get; set; }

        public ICollection<ResourceFolderChild> SubFolders { get; set; } = new HashSet<ResourceFolderChild>();

        public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();
    }
}
