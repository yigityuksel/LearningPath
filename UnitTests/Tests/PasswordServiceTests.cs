using System;
using NUnit.Framework;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Services;

namespace UnitTests.Tests
{
    [TestFixture]
    public class PasswordServiceTests
    {

        private IPasswordService _passwordService;
        private string _salt;
        private string _password;

        [SetUp]
        public void PasswordServiceTestsSetup()
        {
           _passwordService = new PasswordService();
            _password = "1234";
            _salt = Guid.NewGuid().ToString();
        }

        [Test]
        public void CalculateHashPassword()
        {
            var hashedPassword = _passwordService.CalculateHashedPassword(_password, _salt);
            Assert.IsNotNull(hashedPassword);
        }

    }
}