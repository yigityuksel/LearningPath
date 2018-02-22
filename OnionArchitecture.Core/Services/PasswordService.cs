using System.Security.Cryptography;
using System.Text;
using OnionArchitecture.Core.Interfaces.Services;

namespace OnionArchitecture.Core.Services
{
    public class PasswordService : IPasswordService
    {
        public string CalculateHashedPassword(string password, string salt)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(password + salt);
                var hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                var sb = new StringBuilder();
                foreach (var t in hashBytes)
                {
                    sb.Append(t.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}