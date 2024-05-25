using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFeed.Domain.Models
{
    public class Follow
    {
        public int Id { get; set; }

        public int FollowerId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User? Follower { get; set; }

        public int FolloweeId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User? Followee { get; set; }
    }
}
