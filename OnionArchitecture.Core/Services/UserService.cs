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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
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

    }
}