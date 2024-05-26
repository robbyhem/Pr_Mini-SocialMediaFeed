using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFeed.Domain.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int? pageNumber = null, int? pageSize = null);
        IEnumerable<T> GetAll(string?[] include, Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter, string[] include);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
