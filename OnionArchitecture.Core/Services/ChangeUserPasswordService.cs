using System;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Services
{
    public class ChangeUserPasswordService : IChangeUserPasswordService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserPasswordHistoryService _userPasswordHistoryService;
        private readonly IPasswordService _passwordService;

        public ChangeUserPasswordService(IUserRepository userRepository, IUserPasswordHistoryService userPasswordHistoryService, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _userPasswordHistoryService = userPasswordHistoryService;
            _passwordService = passwordService;
        }

        public User ChangeUserPassword(User user, string newPassword)
        {

            if (_userPasswordHistoryService.IsPasswordUsedBefore(user.Id, newPassword))
                throw new PasswordUsedBeforeException("The password cannot same as previous 5 passwords");

            user.Salt = Guid.NewGuid().ToString();
            user.Password = _passwordService.CalculateHashedPassword(newPassword, user.Salt);
            user.PasswordCreationTime = DateTime.Now;

            return _userRepository.UpdateUser(user);
        }
    }
}