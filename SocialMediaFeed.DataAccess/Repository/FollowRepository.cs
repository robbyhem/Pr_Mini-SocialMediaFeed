using SocialMediaFeed.DataAccess.Data;
using SocialMediaFeed.Domain.Interface;
using SocialMediaFeed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFeed.DataAccess.Repository
{
    public class FollowRepository(ApplicationDbContext context) : Repository<Follow>(context), IFollowRepository
    {
        private readonly ApplicationDbContext _context;
        public void Update(Follow entity)
        {
            _context.Follows.Update(entity);
        }
    }
}
