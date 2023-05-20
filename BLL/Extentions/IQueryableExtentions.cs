using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Extentions
{
    public static class IQueryableExtentions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> list, Expression<Func<T, bool>> expression)
        {
            return list.Where(expression);
        }
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int page, int pageSize)
        {
            
            int skip = Math.Max(pageSize * (page - 1), 0);
            
            return query.Skip(skip).Take(pageSize);
        }
       



    }
}
