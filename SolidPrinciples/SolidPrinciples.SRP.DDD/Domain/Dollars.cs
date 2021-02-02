using System.Collections.Generic;

namespace SolidPrinciples.SRP.DDD.Domain
{
    public class Dollars
    {
        private const decimal MaxDollarAmount = 1_000_000;

        public decimal Value { get; }

        public bool IsZero => Value == 0;

        private Dollars(decimal value)
        {
            Value = value;
        }

        public static Dollars Create(decimal dollarAmount)
        {
            return new Dollars(dollarAmount);
        }

        public static Dollars Of(decimal dollarAmount)
        {
            return Create(dollarAmount);
        }

        public static Dollars operator *(Dollars dollars, decimal multiplier)
        {
            return new Dollars(dollars.Value * multiplier);
        }

        public static Dollars operator +(Dollars dollars1, Dollars dollars2)
        {
            return new Dollars(dollars1.Value + dollars2.Value);
        }
    }
}
