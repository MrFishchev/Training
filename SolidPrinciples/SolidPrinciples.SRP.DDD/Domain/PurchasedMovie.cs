using System;

namespace SolidPrinciples.SRP.DDD.Domain
{
    public class PurchasedMovie : Entity
    {
        public Movie Movie { get; }
        
        public Customer Customer { get; }
        public Dollars Price { get; }

        public PurchasedMovie( Movie movie, Customer customer, Dollars price)
        {
            if (price == null || price.IsZero)
                throw new ArgumentException(nameof(price));

            Movie = movie;
            Customer = customer;
            Price = price;
        }
    }
}
