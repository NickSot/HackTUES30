using System;
using System.ComponentModel.DataAnnotations;

namespace GoodGuysCommunity.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public DateTime CommentDate { get; set; }

        public User Author { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
