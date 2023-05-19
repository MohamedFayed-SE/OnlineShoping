using BAL;
using BAL.Models;
using BLL.Extentions;
using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class ProductRepo : BaseRepo<Product, int>, IProduct

    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext contex) : base(contex)
        {
            _context = contex;
        }

        public IQueryable<IGrouping<ICollection<SubCategory>, IGrouping<Category, Product>>> GetProductPageGroupedByCategories(int page, int pageSize)
        {
           var result= _context.products.Page(page, pageSize).OrderBy(p => p.LatinName)
                .Include(p=>p.SubCategory).ThenInclude(p=>p.Category)
                .GroupBy(p => p.SubCategory.Category).GroupBy(p => p.Key.SubCategories);
            return result;

        }
    }
}
