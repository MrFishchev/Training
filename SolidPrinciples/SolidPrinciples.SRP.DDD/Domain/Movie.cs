using System;

namespace SolidPrinciples.SRP.DDD.Domain
{
    public class Movie : Entity
    {
        public string Name { get; }

        public Movie(string name)
        {
            Name = name;
        }

        public Dollars CalculatePrice(CustomerStatus status, DateTime now)
        {
            decimal modifier = 1 - status.GetDiscount(now);
            return GetBasePrice() * modifier;
        }

        private Dollars GetBasePrice()
        {
            return Dollars.Of(10);
        }
    }
}
