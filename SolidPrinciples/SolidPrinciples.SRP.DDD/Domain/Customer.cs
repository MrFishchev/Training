using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidPrinciples.SRP.DDD.Domain
{
    public class Customer : Entity
    {
        public CustomerName Name { get; set; }
        public CustomerStatus Status { get; private set; }
        public Dollars MoneySpent { get; private set; }

        private readonly IList<PurchasedMovie> _purchasedMovies = new List<PurchasedMovie>();
        public IReadOnlyList<PurchasedMovie> PurchasedMovies => _purchasedMovies.ToList();

        public Customer(CustomerName name)
        {
            Name = name;
            MoneySpent = Dollars.Of(0);
            Status = CustomerStatus.Regular;
        }

        public bool HasPurchasedMovie(Movie movie)
        {
            return PurchasedMovies.Any(x => x.Movie.Id == movie.Id);
        }

        public void PurchaseMovie(Movie movie)
        {
            if (HasPurchasedMovie(movie))
                throw new Exception();

            var price = movie.CalculatePrice(Status, DateTime.UtcNow);

            var purchasedMovie = new PurchasedMovie(movie, this, price);
            _purchasedMovies.Add(purchasedMovie);
            
            MoneySpent += price;
        }

        public void Promote()
        {
            Status = Status.Promote();
        }
    }
}
