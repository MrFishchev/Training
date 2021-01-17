using System;

namespace SolidPrinciples.SRP.Correct
{
    public class UserService
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public UserService(IEmailService emailService, IUserRepository userRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
        }
        
        public void RegisterUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException();

            _userRepository.AddUser(username);
            _emailService.SendMessage("Welcome...");
        }
    }
}