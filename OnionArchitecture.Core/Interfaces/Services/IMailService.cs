namespace OnionArchitecture.Core.Interfaces.Services
{
    public interface IMailService
    {
        bool SendMail(string willSendMailAddress, string content);
    }
}