using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaShopping.Models
{
    public record InvalidCart(List<UnvalidatedOrderInfo> OrderList, string Address);
}
