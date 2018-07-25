using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Data.Relations
{
    public class ResourceFolderChild
    {
        public int FolderId { get; set; }

        public ResourceFolder Folder { get; set; }

        public int ChildId { get; set; }

        public ResourceFolder Child { get; set; }
    }
}
