using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaShopping.Models
{
    public record ValidCart(List<OrderInfo> OrderList, Address Address);
}
