using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
   there is Two Way to make the relation between Category And Sub category based on 
Business  need if sub catgeory can have children then we will make slef join
instead of sperate it in another table  and will make the realtion between  product and 
category 

 */
namespace BAL.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

      /* -----------self joining --------------------- 
       public byte ParentId { get; set; }
        public Category   ParentCategory { get; set; }
         
        public  ICollection<Category> SubCategories { get; set; }*/
        
        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }




    }
}
