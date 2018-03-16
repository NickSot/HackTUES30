using System;
using System.ComponentModel.DataAnnotations;

namespace GoodGuysCommunity.Data
{
    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string FilePath { get; set; }

        public DateTime UploadDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
