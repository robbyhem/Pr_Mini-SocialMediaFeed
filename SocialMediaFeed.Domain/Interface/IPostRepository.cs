using SocialMediaFeed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFeed.Domain.Interface
{
    public interface IPostRepository : IRepository<Post>
    {
        void Update(Post post);
    }
}
