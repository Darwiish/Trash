using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashVersionOne.Models
{
    public interface IProductRepository
    {
        IQueryable<ProductDetails> Products { get; }
        void SaveProduct(ProductDetails product);
        ProductDetails DeleteProduct(int productID);
    }
}
