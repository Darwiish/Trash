using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashVersionOne.Data;

namespace TrashVersionOne.Models
{
    public class EFProductRepository :IProductRepository
    {
        private ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<ProductDetails> Products => context.ProductDetails;
        public void SaveProduct(ProductDetails product)
        {
            if (product.Id == 0)
            {
                context.ProductDetails.Add(product);
            }
            else
            {
                ProductDetails dbEntry = context.ProductDetails
                .FirstOrDefault(p => p.Id == product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Product_Name = product.Product_Name;
                    dbEntry.Product_Description = product.Product_Description;
                    dbEntry.Amount = product.Amount;
                    dbEntry.Product_category = product.Product_category;
                    dbEntry.ProductPicture = product.ProductPicture;
                }
            }
            context.SaveChanges();
        }
        public ProductDetails DeleteProduct(int productID)
        {
            ProductDetails dbEntry = context.ProductDetails
            .FirstOrDefault(p => p.Id == productID);
            if (dbEntry != null)
            {
                context.ProductDetails.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
