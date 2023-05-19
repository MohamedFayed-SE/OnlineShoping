using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

            /*        self joining 
       /*public byte SubCategoryId { get; set; }
        public Category   SubCategory { get; set; }
         
        public  ICollection<Category> SubCategories { get; set; }*/
        
        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }




    }
}
