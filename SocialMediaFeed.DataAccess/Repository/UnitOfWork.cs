using SocialMediaFeed.DataAccess.Data;
using SocialMediaFeed.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFeed.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Post = new PostRepository(_context);
            Follow = new FollowRepository(_context);
            User = new UserRepository(_context);
        }

        public IPostRepository Post { get; private set; }

        public IFollowRepository Follow { get; private set; }

        public IUserRepository User { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
