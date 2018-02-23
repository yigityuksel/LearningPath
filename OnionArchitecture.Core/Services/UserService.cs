﻿using System;
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

        public UserService(IUserRepository userRepository, IUserPasswordHistoryService userPasswordHistoryService)
        {
            _userRepository = userRepository;
            _userPasswordHistoryService = userPasswordHistoryService;
        }

        public User AddUser(User user)
        {

            var result = _userRepository.AddUser(user);

            if (result != null)
            {
                _userPasswordHistoryService.SaveUserPreviousPassword(new UserPasswordHistory()
                {
                    Salt = user.Salt,
                    Password = user.Password,
                    Id = Guid.NewGuid(),
                    User = user,
                    CreationDateTime = user.PasswordCreationTime
                });
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

    }
}