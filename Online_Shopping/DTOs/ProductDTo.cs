using BAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Online_Shopping.DTOs
{
    public class ProductDTo
    {
        public int? Id { get; set; }
        [MaxLength(150),Required,RegularExpression(@"^([\u0621-\u064A\s\p{N}]{2,})[ |\u0621-\u064A\s\p{N}]{0,}$",ErrorMessage = "PLease Enter Only Arabic characters")]
        public string LocalName { get; set; }
        [MaxLength(300),Required,RegularExpression(@"^([a-z|A-Z]{2,})[ |A-z|a-z]{0,}$", ErrorMessage = "Please Enter Only  English characters")]
        public string LatinName { get; set; }
        [MaxLength(300),Required]
        public string Description { get; set; }
        
        public string? ImgeName { get; set; }
        [Required]
        public IFormFile? Imge { get; set; }
        [Required]
        public byte CategoryId { get; set; }
      
        public Category? Category { get; set; }
        [Required]
        public byte? SubCategoryId { get; set; }
        
        public SubCategoryDTo? SubCategory { get; set; }
        [Required]
        public bool HasAvailableStock { get; set; }
    }
}
