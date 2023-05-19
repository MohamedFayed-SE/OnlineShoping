using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.DTOs
{
    public class CategoryDTo
    {
       
        public byte? Id { get; set; }

        [MaxLength(100),Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }= DateTime.Now;

        




    }
}
