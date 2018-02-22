using System;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPasswordHistoryService _userPasswordHistoryService;
        private readonly IPasswordService _passwordService;

        public UserService(IUserRepository userRepository, IUserPasswordHistoryService userPasswordHistoryService, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _userPasswordHistoryService = userPasswordHistoryService;
            _passwordService = passwordService;
        }

        public User AddUser(User user)
        {

            var result = _userRepository.AddUser(user);

            if (result != null)
            {
                var passwordHistory = new UserPasswordHistory()
                {
                    Salt = user.Salt,
                    Password = user.Password,
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    CreationDateTime = user.PasswordCreationTime
                };
                _userPasswordHistoryService.SaveUserPreviousPassword(passwordHistory);
            }

            return result;

        }

        public User GetUserByUserName(string username)
        {

            var user = _userRepository.GetUserByUserName(username);

            if (user == null)
                throw new UserNotFoundException();

            return user;
        }

        public User GetUserByUserId(Guid userId)
        {
            var user = _userRepository.GetUserByUserId(userId);

            if (user == null)
                throw new UserNotFoundException();

            return user;
        }

        public User ChangeUserPassword(User user, string newPassword)
        {

            if(_userPasswordHistoryService.IsPasswordUsedBefore(user.Id, newPassword))
                throw new PasswordUsedBeforeException("The password cannot same as previous 5 passwords");

            var passwordHistory = new UserPasswordHistory()
            {
                Salt = user.Salt,
                Password = user.Password,
                Id = Guid.NewGuid(),
                UserId = user.Id,
                CreationDateTime = user.PasswordCreationTime
            };

            user.Salt = Guid.NewGuid().ToString();
            user.Password = _passwordService.CalculateHashedPassword(newPassword, user.Salt);
            user.PasswordCreationTime = DateTime.Now;

            var result = _userRepository.UpdateUser(user);

            if (result != null)
            {
                //save to history,
                _userPasswordHistoryService.SaveUserPreviousPassword(passwordHistory);
            }

            return result;

        }
    }
}