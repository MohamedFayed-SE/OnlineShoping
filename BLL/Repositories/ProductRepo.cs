using BAL;
using BAL.Models;
using BLL.Extentions;
using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<Dictionary<string,ICollection<Product>>> GetProductPageGroupedByCategories()
        {
            var categories = await _context.categories.ToListAsync();
            var groupedProducts=new Dictionary<string,ICollection<Product>>();   
            foreach (var item in categories)
            {

                var products = await _context.products.Where(p => p.CategoryId == item.Id)
                             .OrderBy(d => d.LatinName).ToListAsync();

                groupedProducts.Add(item.Name, products);



                                             
            }
            return groupedProducts;
        }
    }
}

