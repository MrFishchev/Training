using System.Linq;
using SolidPrinciples.SRP.DDD.Domain;

namespace SolidPrinciples.SRP.DDD.App
{
    public class MovieRepository
    {
        private static readonly Movie[] _allMovies =
        {
            new Movie("Great Gatsby")
            {
                Id = 1
            },
            new Movie("Secret Life of Pets")
            {
                Id = 2
            }
        };

        public Movie GetById(long movieId)
        {
            return _allMovies.SingleOrDefault(x => x.Id == movieId);
        }
    }
}
