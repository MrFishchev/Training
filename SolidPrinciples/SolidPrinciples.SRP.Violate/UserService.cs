using System;

namespace SolidPrinciples.SRP.Violate
{
    public class UserService
    {
        #region Mocks

        private class SqlConnection
        {
            public void Open(){}
            public void ExecuteCommand(string command){}
        }
    
        private class SmtpClient
        {
            public void SendMessage(string message){}
        }
    
        #endregion

        public void RegisterUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException();

            var connection = new SqlConnection();
            connection.Open();
            connection.ExecuteCommand("INSERT INTO ...");

            var smtpClient = new SmtpClient();
            smtpClient.SendMessage("Welcome...");
        }
    }
}