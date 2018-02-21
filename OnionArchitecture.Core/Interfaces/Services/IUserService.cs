using System;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Services
{
    public interface IUserService
    {
        User AddUser(User user);

        User GetUserByUserName(string username);

        User GetUserByUserId(Guid userId);

        User ChangeUserPassword(Guid userId, string newPassword);
    }
}