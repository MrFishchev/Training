using System;
using System.Collections.Generic;

namespace SolidPrinciples.SRP.DDD.Domain
{
    public class CustomerStatus
    {
        public static readonly CustomerStatus Regular = new CustomerStatus(CustomerStatusType.Regular);

        public CustomerStatusType Type { get; }
        
        private CustomerStatus()
        {
        }

        private CustomerStatus(CustomerStatusType type)
            : this()
        {
            Type = type;
        }

        public bool IsAdvanced(DateTime now)
        {
            return Type == CustomerStatusType.Advanced;
        }

        public decimal GetDiscount(DateTime now)
        {
            return IsAdvanced(now) ? 0.25m : 0m;
        }

        public CustomerStatus Promote()
        {
            return new CustomerStatus(CustomerStatusType.Advanced);
        }
    }

    public enum CustomerStatusType
    {
        Regular = 1,
        Advanced = 2
    }
}
