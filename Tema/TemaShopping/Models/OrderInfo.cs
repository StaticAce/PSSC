using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaShopping.Models
{
    public record OrderInfo
    {
        public ProductNumber ProductNumber { get; set; }

        public Quantity Quantity { get; set; }

        public double Price { get; set; }

        public OrderInfo(ProductNumber productNumber, Quantity quantity, double price)
        {
            ProductNumber = productNumber;
            Quantity = quantity;
            Price = price;
        }
    }
}
