using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.DTOs
{
    public class SubCategoryDTo
    {
        
        public byte? Id { get; set; }

        [MaxLength(100),Required]
        public string Name { get; set; }
        [Required]
        public byte CategoryId { get; set; }
        public CategoryDTo? Category { get; set; }

    }
}
