using OnionArchitecture.Core.Interfaces.Services;

namespace OnionArchitecture.Infra.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public AuthenticationService(IUserService userService, IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        public bool AreValidUserCrendentials(string userName, string password)
        {
            var user = _userService.GetUserByUserName(userName);
            var hashedPassword = _passwordService.CalculateHashedPassword(password, user.Salt);

            return user.Password == hashedPassword;
        }
    }
}