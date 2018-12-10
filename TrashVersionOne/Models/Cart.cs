using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashVersionOne.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(ProductDetails product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.Id == product.Id)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(ProductDetails product) =>
        lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        public virtual decimal ComputeTotalValue() =>
        lineCollection.Sum(e => e.Product.Amount * e.Quantity);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

      public class CartLine
    {
        public int CartLineID { get; set; }
        public ProductDetails Product { get; set; }
        public int Quantity { get; set; }
    }
}
