using BAL;
using BLL.Extentions;
using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class BaseRepo<T, TId>:IBaseRepo<T,TId> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepo(ApplicationDbContext contex)
        {
            _context = contex;
        }

        public async Task<T> CreateAsync(T modal)
        {
            await _context.Set<T>().AddAsync(modal);

            return modal;

        }

        public async Task<T> Delete(TId Id)
        {
            var result = await this.FindByIdAsync(Id);

            _context.Set<T>().Remove(result);


            return result;

        }

        /// <summary>
        ///  FIlter Method Have One Overloading one with  expression filter and one with includes
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IQueryable<T> Filter(Expression<Func<T, bool>> expression)
        {
            var result = _context.Set<T>().AsTracking().Filter(expression);
            return result;
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> expression, List<string> includes)
        {
            IQueryable<T> result = _context.Set<T>();
            foreach (var include in includes)
            {
                result = result.Include(include);
            }


            return result.AsNoTracking().Where(expression);
        }

        public async Task<T> FindByIdAsync(TId Id)
        {

            var result = await _context.Set<T>().FindAsync(Id);
          
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        

        public async Task<IEnumerable<T>> GetAllAsync(List<string> includes)
        {

            IQueryable<T> result = _context.Set<T>();

            foreach (var include in includes)
                result = result.Include(include);


            return await result.AsNoTracking().ToListAsync();




        }
       public async Task<IEnumerable<T>> GetAllAsync(string include)
        {
         return  await  _context.Set<T>().Include(include).AsNoTracking().ToListAsync();
        }

        public int GetCount()
        {
            return _context.Set<T>().Count();  
        }

        public IQueryable<T> GetPage(int page, int pageSize)
        {
             return _context.Set<T>().Page(page, pageSize).AsTracking();
        }
        public IQueryable<T> GetPage(int page, int pageSize,string Include)
        {
            return _context.Set<T>().Page(page, pageSize).Include(Include).AsTracking();
        }
        public IQueryable<T> GetPage(int page, int pageSize, List<string> Includes)
        {
            IQueryable<T> result = _context.Set<T>();
            foreach (var include in Includes)
            {
                result = result.Include(include);
            }
            return result.Page(page, pageSize).AsTracking();
        }

        public async Task<T> UpdateAsync(T modal)
        {

            _context.Set<T>().Update(modal);

            return modal;
        }
    }
}
