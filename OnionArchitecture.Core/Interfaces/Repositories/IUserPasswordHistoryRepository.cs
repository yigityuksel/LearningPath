using System;
using System.Collections.Generic;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Repositories
{
    public interface IUserPasswordHistoryRepository
    {
        bool SaveUserPreviousPassword(UserPasswordHistory userPassword);
        List<UserPasswordHistory> GetUserPreviousPasswordList(Guid userId);
    }
}