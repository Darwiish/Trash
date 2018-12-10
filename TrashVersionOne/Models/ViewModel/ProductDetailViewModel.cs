using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashVersionOne.Models.ViewModel
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string category { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string ProductImage{ get; set; }


        
    }
}
