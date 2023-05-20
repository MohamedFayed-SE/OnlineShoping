using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 there is Two Way to make the relation between Product And product category based on 
Business  need if sub catgeory can have children then we will make slef join
instead of sperate it in another table  and will make the realtion between  product and 
category 


 */

namespace BAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string LocalName { get; set; }
        [MaxLength(300)]
        public string LatinName { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
         public string ImgeName { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
        public byte CategoryId { get; set; }
        public Category Category { get; set; }
        public byte? SubCategoryId { get; set; }
        public SubCategory? SubCategory   { get; set; }

        public bool HasAvailableStock { get; set; }


    }
}
