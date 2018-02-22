using System;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);

        User GetUserByUserName(string username);

        User GetUserByUserId(Guid userId);

        User UpdateUser(User user);
    }
}