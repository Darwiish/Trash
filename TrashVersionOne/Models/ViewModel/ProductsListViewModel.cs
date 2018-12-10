using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashVersionOne.Models.ViewModel
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductDetails> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
