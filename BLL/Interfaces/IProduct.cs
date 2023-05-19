using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProduct:IBaseRepo<Product,int>
    {
        IQueryable<IGrouping<ICollection<SubCategory>,IGrouping<Category,Product>>> GetProductPageGroupedByCategories(int page, int pageSize);
    }
}
