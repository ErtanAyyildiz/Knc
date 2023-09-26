using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knc.Entity.Modals
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string SubCategoryName { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        public CartItem()
        {
        }

        public CartItem(Product product, int quantity)
        {
            ProductId = product.Id;
            ProductTitle = product.Title;
            Quantity = quantity;
            ImageUrl = product.ImageUrl;
        }

    }
}
