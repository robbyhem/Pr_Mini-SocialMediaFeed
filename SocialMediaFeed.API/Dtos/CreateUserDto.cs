using SocialMediaFeed.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaFeed.API.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string? UserName { get; set; }

        //public ICollection<PostDto>? Posts { get; set; }
        //public ICollection<FollowDto>? Following { get; set; }
        //public ICollection<FollowDto>? Followers { get; set; }
    }
}
