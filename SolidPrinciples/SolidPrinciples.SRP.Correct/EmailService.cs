namespace SolidPrinciples.SRP.Correct
{
    public interface IEmailService
    {
        void SendMessage(string message);
    }

    public class EmailService : IEmailService
    {
        public void SendMessage(string message)
        {
            //implementation
        }
    }
}