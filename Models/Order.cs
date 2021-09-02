using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPIA2.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string  UserName { get; set; }
        [Required]
        public string ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
