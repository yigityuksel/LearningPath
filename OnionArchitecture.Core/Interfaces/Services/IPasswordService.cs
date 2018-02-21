namespace OnionArchitecture.Core.Interfaces.Services
{
    public interface IPasswordService
    {
        string CalculateHashedPassword(string password, string salt);
    }
}