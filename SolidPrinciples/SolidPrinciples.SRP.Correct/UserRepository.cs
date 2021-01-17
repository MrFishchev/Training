namespace SolidPrinciples.SRP.Correct
{
    public interface IUserRepository
    {
        void AddUser(string username);
    }

    public class UserRepository : IUserRepository
    {
        public void AddUser(string username)
        {
            //implementation
        }
    }
}