using System;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Infra.Services
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

        public User ChangeUserPassword(Guid userId, string newPassword)
        {

            if(_userPasswordHistoryService.IsPasswordUsedBefore(userId, newPassword))
                throw new PasswordUsedBeforeException("The password cannot same as previous 5 passwords");

            var currentUser = _userRepository.GetUserByUserId(userId);

            var passwordHistory = new UserPasswordHistory()
            {
                Salt = currentUser.Salt,
                Password = currentUser.Password,
                Id = Guid.NewGuid(),
                UserId = currentUser.Id,
                CreationDateTime = currentUser.PasswordCreationTime
            };

            currentUser.Salt = Guid.NewGuid().ToString();
            currentUser.Password = _passwordService.CalculateHashedPassword(newPassword, currentUser.Salt);
            currentUser.PasswordCreationTime = DateTime.Now;

            var result = _userRepository.ChangeUserPassword(currentUser);

            if (result != null)
            {
                //save to history,
                _userPasswordHistoryService.SaveUserPreviousPassword(passwordHistory);
            }

            return result;

        }
    }
}