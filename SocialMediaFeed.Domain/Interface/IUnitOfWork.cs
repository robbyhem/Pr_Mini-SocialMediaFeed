using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFeed.Domain.Interface
{
    public interface IUnitOfWork
    {
        IPostRepository Post { get; }
        IFollowRepository Follow { get; }
        IUserRepository User { get; }
        void Save();
    }
}
