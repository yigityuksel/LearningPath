using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Services
{
    public interface IChangeUserPasswordService
    {
        User ChangeUserPassword(User user, string newPassword);
    }
}