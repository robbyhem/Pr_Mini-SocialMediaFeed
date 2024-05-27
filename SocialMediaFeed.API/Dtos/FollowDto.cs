namespace SocialMediaFeed.API.Dtos
{
    public class FollowDto : CreateFollowDto
    {
        public int Id { get; set; }
        public string? FollowerUserName { get; set; }
        public string? FolloweeUserName { get; set; }
    }
}
