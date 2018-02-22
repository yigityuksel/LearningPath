using System;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Services
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

        public UserPasswordHistory SaveUserPreviousPassword(UserPasswordHistory userPassword)
        {
            try
            {
                return _userPasswordHistoryRepository.SaveUserPreviousPassword(userPassword);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }    
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