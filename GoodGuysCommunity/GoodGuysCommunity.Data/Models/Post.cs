using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GoodGuysCommunity.Data.Models;

namespace GoodGuysCommunity.Data
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
