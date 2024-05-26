using Microsoft.EntityFrameworkCore;
using SocialMediaFeed.Domain.Models;

namespace SocialMediaFeed.API.Dtos
{
    public class CreateFollowDto
    {
        public string? Follower { get; set; }

        public string? Followee { get; set; }
    }
}
