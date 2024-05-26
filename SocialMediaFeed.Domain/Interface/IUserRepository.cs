using SocialMediaFeed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFeed.Domain.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
    }
}
