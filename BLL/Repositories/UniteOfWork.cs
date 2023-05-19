using BAL;
using BAL.Models;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class UniteOfWork:IUniteOfWork
    {
       public IBaseRepo<Category, byte> Categories { get; private set; }
       public IBaseRepo<SubCategory, byte> SubCategories { get; private set; }

       public IProduct Products { get; private set; }
      

        private readonly ApplicationDbContext _contex;
        public UniteOfWork(ApplicationDbContext context)
        {
            _contex = context;
            Categories = new BaseRepo<Category,byte>(_contex);
            SubCategories = new BaseRepo<SubCategory,byte>(_contex);
            Products = new ProductRepo(_contex);
           
           
        }

        public async Task<int> SaveChangesAsync()
        {
          return await  _contex.SaveChangesAsync(); 
        }

        public void Dispose()
        {
            _contex.Dispose();
        }
    }
}
