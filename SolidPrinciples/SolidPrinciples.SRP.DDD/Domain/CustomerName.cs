using System.Collections.Generic;

namespace SolidPrinciples.SRP.DDD.Domain
{
    public class CustomerName
    {
        public string Value { get; }

        private CustomerName(string value)
        {
            Value = value;
        }

        public static CustomerName Create(string customerName)
        {
            customerName = (customerName ?? string.Empty).Trim();
            return new CustomerName(customerName);
        }
    }
}
