using SocialMediaFeed.Domain.Models;

namespace SocialMediaFeed.API.Dtos
{
    public class CreatePostDto
    {
        public string? Text { get; set; }

        public DateTime CreatedAt { get; set; } //= DateTime.UtcNow;

        public int Likes { get; set; }

        public object? User { get; set; }
    }
}
