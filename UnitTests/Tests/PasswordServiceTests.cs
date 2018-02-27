using System;
using NUnit.Framework;
using OnionArchitecture.Core.Services;

namespace UnitTests.Tests
{
    [TestFixture]
    public class PasswordServiceTests
    {
        private PasswordService _passwordService;

        [SetUp]
        public void SetUp()
        {
            _passwordService = new PasswordService();
        }

        [Test]
        public void CalculateHashPasswordThrowsArgumentNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => { _passwordService.CalculateHashedPassword(string.Empty, string.Empty); });
        }

        [Test]
        public void CalculateHashPasswordTest()
        {
            Assert.That(_passwordService.CalculateHashedPassword("1234", "1234"), Is.EqualTo("ED2B1F468C5F915F3F1CF75D7068BAAE"));
        }
    }
}