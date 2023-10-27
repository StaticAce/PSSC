using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaShopping.Exceptions;

namespace TemaShopping.Models
{
    public record Address
    {
        public string Value { get; }

        public Address(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidAddressException($"{value} is an invalid address value.");
            }
        }

        public static bool TryParse(string value, out Address? address)
        {
            if (!string.IsNullOrEmpty(value))
            {
                address = new Address(value);
                return true;
            }
            address = null;
            return false;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
