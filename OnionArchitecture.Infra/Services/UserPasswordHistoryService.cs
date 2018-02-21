using System;
using System.Data.Entity.Infrastructure;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Infra.Context;

namespace OnionArchitecture.Infra.Services
{
    public class UserPasswordHistoryService : IUserPasswordHistoryService
    {
        private readonly IUserPasswordHistoryRepository _userPasswordHistoryRepository;
        private readonly IPasswordService _passwordService;

        public UserPasswordHistoryService(IUserPasswordHistoryRepository userPasswordHistoryRepository, IPasswordService passwordService)
        {
            _userPasswordHistoryRepository = userPasswordHistoryRepository;
            _passwordService = passwordService;
        }

        public void SaveUserPreviousPassword(UserPasswordHistory userPassword)
        {
            if (!_userPasswordHistoryRepository.SaveUserPreviousPassword(userPassword))
                throw new CommitFailedException();
        }

        public bool IsPasswordUsedBefore(Guid userId, string password)
        {

            var passwordHistoryList = _userPasswordHistoryRepository.GetUserPreviousPasswordList(userId);

            foreach (var passwordHistory in passwordHistoryList)
            {
                if (_passwordService.CalculateHashedPassword(password, passwordHistory.Salt) ==
                    passwordHistory.Password)
                    return true;
            }

            return false;
        }

    }
}