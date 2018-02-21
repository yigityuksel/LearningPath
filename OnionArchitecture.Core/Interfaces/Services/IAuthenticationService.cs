namespace OnionArchitecture.Core.Interfaces.Services
{
    public interface IAuthenticationService
    {
        bool AreValidUserCrendentials(string userName, string password);
    }
}