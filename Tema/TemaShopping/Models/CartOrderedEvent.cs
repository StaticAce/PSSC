using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaShopping.Models
{
    [AsChoice]
    public static partial class CartOrderedEvent
    {
        public interface ICartOrderedEvent { }

        public record SucceededEvent : ICartOrderedEvent
        {
            public string Csv { get; }
            public double Price { get; }

            internal SucceededEvent(string csv, double price)
            {
                Csv = csv;
                Price = price;
            }
        }

        public record FailedEvent : ICartOrderedEvent
        {
            public string Reason { get; }

            internal FailedEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}
