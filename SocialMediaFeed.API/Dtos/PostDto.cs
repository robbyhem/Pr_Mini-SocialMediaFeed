namespace SocialMediaFeed.API.Dtos
{
    public class PostDto : CreatePostDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UserName { get; set; }
    }
}
