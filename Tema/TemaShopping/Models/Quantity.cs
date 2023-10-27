using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TemaShopping.Exceptions;

namespace TemaShopping.Models
{
    public record Quantity
    {
        public int Value { get; }

        public Quantity(int value)
        {
            if (value > 0)
            {
                Value = value;
            }
            else
            {
                throw new InvalidQuantityException($"{value} is an invalid Quantity.");
            }
        }

        public static bool TryParse(string value, out Quantity? quantity)
        {
            bool isValid = false;
            quantity = null;
            if (int.TryParse(value, out int numericGrade))
            {
                if (numericGrade > 0)
                {
                    isValid = true;
                    quantity = new(numericGrade);
                }
            }

            return isValid;
        }
    }
}
