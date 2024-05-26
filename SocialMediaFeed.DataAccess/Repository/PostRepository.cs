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
    public class PostRepository(ApplicationDbContext context) : Repository<Post>(context), IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }
    }
}
