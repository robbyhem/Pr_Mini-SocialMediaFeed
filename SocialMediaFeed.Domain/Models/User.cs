using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFeed.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        public ICollection<Post>? Posts { get; set; } //= new List<Post>();
        public ICollection<Follow>? Following { get; set; } //= new List<Follow>();
        public ICollection<Follow>? Followers { get; set; } //= new List<Follow>();
    }
}
