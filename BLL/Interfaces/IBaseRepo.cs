using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBaseRepo<T, TId> where T : class
    {
        Task<T> CreateAsync(T modal);
        Task<T> Delete(TId Id);
        Task<T> UpdateAsync(T modal);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(List<string> includes);
        Task<IEnumerable<T>> GetAllAsync(string include);
        IQueryable<T> GetPage(int page, int pageSize);
        IQueryable<T> GetPage(int page, int pageSize, string Include);
        IQueryable<T> GetPage(int page, int pageSize, List<string> Includes);
        int GetCount();
        Task<T> FindByIdAsync(TId Id);

        IQueryable<T> Filter(Expression<Func<T, bool>> expression);
        IQueryable<T> Filter(Expression<Func<T, bool>> expression, List<string> includes);



    }






    }
