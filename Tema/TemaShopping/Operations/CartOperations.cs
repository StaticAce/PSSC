using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaShopping.Models;
using static TemaShopping.Models.CartStates;

namespace TemaShopping.Operations
{
    public class CartOperations
    {
        public static ICartState ValidateCart(Unvalidated unvalidated)
        {
            if (!unvalidated.Cart.OrderList.Any())
                return new Empty();

            List<OrderInfo> orderInfos = new();
            bool isValidList = true;
            string invalidReson = string.Empty;
            List<Product> products = DatabaseNotReally.LoadProducts().ToList();

            foreach (var unvalidatedOrderInfo in unvalidated.Cart.OrderList)
            {
                if (!ProductNumber.TryParse(unvalidatedOrderInfo.ProductNumber, out ProductNumber? productNumber))
                {
                    invalidReson = $"Invalid product number: ({unvalidatedOrderInfo.ProductNumber})";
                    isValidList = false;
                    break;
                }
                if (!Quantity.TryParse(unvalidatedOrderInfo.Quantity, out Quantity? quantity))
                {
                    invalidReson = $"Invalid quantity: ({unvalidatedOrderInfo.Quantity}) for product number: ({unvalidatedOrderInfo.ProductNumber})";
                    isValidList = false;
                    break;
                }
                if(!products.Any(p=>p.ProductNumber==unvalidatedOrderInfo.ProductNumber))
                {
                    invalidReson = $"Product: ({unvalidatedOrderInfo.ProductNumber}) does not exist";
                    isValidList = false;
                    break;
                }
                Product product = products.First(p => p.ProductNumber == unvalidatedOrderInfo.ProductNumber);
                if (product.Quantity < quantity!.Value)
                {
                    invalidReson = $"Product: ({unvalidatedOrderInfo.ProductNumber}) not available";
                    isValidList = false;
                    break;
                }


                OrderInfo validOrder = new(productNumber!, quantity!, product.Price);
                orderInfos.Add(validOrder);
            }

            if (!Address.TryParse(unvalidated.Cart.Address, out Address? address))
            {
                invalidReson = $"Invalid address: ({unvalidated.Cart.Address})";
                isValidList = false;
            } 

            if (isValidList)
            {
                ValidCart validCart = new(orderInfos, address!);

                return new Validated(validCart);
            }
            else
            {
                return new Invalidated(unvalidated.Cart, invalidReson);
            }
        }

        public static ICartState CalculatePrice(ICartState cartState) => cartState.Match(
            whenEmpty: emptyState => emptyState,
            whenUnvalidated: unvalidatedState => unvalidatedState,
            whenInvalidated: invalidatedState => invalidatedState,
            whenOrdered: orderedState => orderedState,
            whenValidated: validatedState => 
            {
                double price = 0;

                foreach (var orderInfo in validatedState.Cart.OrderList)
                {
                    price += orderInfo.Price * orderInfo.Quantity.Value;
                }

                return new Ordered(validatedState.Cart, price);
            });
    }
}
