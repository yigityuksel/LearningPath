using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
    }
}