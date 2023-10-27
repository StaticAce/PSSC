using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaShopping.Models
{
    internal class DatabaseNotReally
    {
        public static IEnumerable<Product> LoadProducts()
        {
            return new List<Product>
            {
                new ("P23", 99, 11.5),
                new ("P11", 1, 10),
                new ("P32", 6, 22.5),
                new ("P21", 4, 5.5),
                new ("P55", 7, 6),
            };
        }
    }
}
