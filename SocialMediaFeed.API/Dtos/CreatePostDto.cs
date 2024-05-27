using SocialMediaFeed.Domain.Models;

namespace SocialMediaFeed.API.Dtos
{
    public class CreatePostDto
    {
        public string? Text { get; set; }
        public int Likes { get; set; }
        public int UserId { get; set; }
    }
}
