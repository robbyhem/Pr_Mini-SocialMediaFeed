using Microsoft.EntityFrameworkCore;
using SocialMediaFeed.Domain.Models;

namespace SocialMediaFeed.API.Dtos
{
    public class CreateFollowDto
    {
        public int FollowerId { get; set; }

        public int FolloweeId { get; set; }
    }
}
