using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaShopping.Models
{
    [AsChoice]
    public static partial class CartStates
    {
        public interface ICartState { }

        public record Empty() : ICartState;

        public record Unvalidated(InvalidCart Cart) : ICartState;

        public record Invalidated(InvalidCart Cart, string reason) : ICartState;

        public record Validated(ValidCart Cart) : ICartState;

        public record Ordered(ValidCart Cart, double Price) : ICartState;
    }
}
