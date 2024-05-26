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
    public class UserRepository(ApplicationDbContext context) : Repository<User>(context), IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
