using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaShopping.Models
{
    public record Product
    {
        public string ProductNumber { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public Product(string productNumber, int quantity, double price)
        {
            ProductNumber = productNumber;
            Quantity = quantity;
            Price = price;
        }
    }
}
