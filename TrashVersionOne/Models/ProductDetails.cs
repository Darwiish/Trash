using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashVersionOne.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }

        [Required]
        public string Product_Name { get; set; }

        public string Product_Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,
       ErrorMessage = "Please enter a positive price")]
        public decimal Amount { get; set; }

        public string Product_category { get; set; }
        public DateTime DateTime { get; set; }
        public string ProductPicture { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }

    }
}
