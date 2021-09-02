using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPIA2.Dtos
{
    public class OrderInputDto
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
