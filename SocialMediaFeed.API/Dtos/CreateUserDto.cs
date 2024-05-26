using SocialMediaFeed.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaFeed.API.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string? UserName { get; set; }

        public ICollection<Post>? Posts { get; set; } //= new List<Post>();
        public ICollection<Follow> Following { get; set; } //= new List<Follow>();
        public ICollection<Follow>? Followers { get; set; } //= new List<Follow>();
    }
}
