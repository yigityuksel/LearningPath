using System;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Services
{
    public interface IUserPasswordHistoryService
    {
        UserPasswordHistory SaveUserPreviousPassword(UserPasswordHistory userPassword);
        bool IsPasswordUsedBefore(Guid userId, string password);
    }
}