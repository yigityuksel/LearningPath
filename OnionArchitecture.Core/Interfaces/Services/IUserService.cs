using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Services
{
    public interface IUserService
    {
        User AddUser(User user);
    }
}