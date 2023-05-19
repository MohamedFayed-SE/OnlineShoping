using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUniteOfWork:IDisposable
    {
        IBaseRepo<Category,byte> Categories { get; }
        IBaseRepo<SubCategory, byte> SubCategories { get; }

        IProduct Products { get;}

        Task<int> SaveChangesAsync();


    }
}
