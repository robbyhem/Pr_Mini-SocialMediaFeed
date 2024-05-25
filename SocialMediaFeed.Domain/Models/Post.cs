using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFeed.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(140)]
        public string? Text { get; set; }

        public DateTime CreatedAt { get; set; } //= DateTime.UtcNow;

        public int Likes { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
