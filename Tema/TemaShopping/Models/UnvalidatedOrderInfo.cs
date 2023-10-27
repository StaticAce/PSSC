using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaShopping.Models
{
    public class UnvalidatedOrderInfo
    {
        public string ProductNumber { get; set; }

        public string Quantity { get; set; }

        public UnvalidatedOrderInfo(string productNumber, string quantity)
        {
            ProductNumber = productNumber;
            Quantity = quantity;
        }
    }
}
