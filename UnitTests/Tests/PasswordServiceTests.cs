using System;
using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Services;

namespace UnitTests.Tests
{
    [TestFixture]
    public class PasswordServiceTests
    {

        private Mock<IPasswordService> _passwordService;

        [SetUp]
        public void PasswordServiceTestsSetup()
        {
           _passwordService = new Mock<IPasswordService>();
        }

        [Test]
        public void CalculateHashPassword()
        {
            _passwordService.Setup(a => a.CalculateHashedPassword("1234", Guid.NewGuid().ToString())).Returns("");
        }

    }
}