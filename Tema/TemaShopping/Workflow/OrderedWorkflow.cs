using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaShopping.Commands;
using TemaShopping.Models;
using static TemaShopping.Models.CartOrderedEvent;
using static TemaShopping.Models.CartStates;
using static TemaShopping.Operations.CartOperations;

namespace TemaShopping.Workflow
{
    public class OrderedWorkflow
    {
        public ICartOrderedEvent Execute(Command command)
        {
            InvalidCart cart = new (command.InputOrderInfos, command.Address);
            ICartState cartState = ValidateCart(new Unvalidated(cart));
            cartState = CalculatePrice(cartState);

            return cartState.Match(
                whenEmpty: emptyState => new FailedEvent("Cart is empty!") as ICartOrderedEvent,
                whenUnvalidated: unvalidatedState => new FailedEvent("Cart is unvalidated!"),
                whenInvalidated: invalidatedState => new FailedEvent(invalidatedState.reason),
                whenValidated: validatedState => new FailedEvent("Order could not be sent"),
                whenOrdered: orderedState => new SucceededEvent(
                    orderedState.Cart.OrderList.Select(o=>$"{o.ProductNumber}, {o.Quantity}, {o.Price}")
                    .Aggregate((acc,el)=>$"{acc}\n{el}"), 
                    orderedState.Price)
                );
        }
    }
}
