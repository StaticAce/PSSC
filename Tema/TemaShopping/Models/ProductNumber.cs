using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TemaShopping.Exceptions;

namespace TemaShopping.Models
{
    public record ProductNumber
    {
        private static readonly Regex ValidPattern = new("^P");

        public string Value { get; }

        public ProductNumber(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidProductNumberException($"{value} is an invalid product number value.");
            }
        }

        public static bool TryParse(string value, out ProductNumber? productNumber)
        {
            if (!string.IsNullOrEmpty(value))
            {
                productNumber = new ProductNumber(value);
                return true;
            }
            productNumber = null;
            return false;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
