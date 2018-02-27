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

        private Mock<IPasswordService> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IPasswordService>();
        }

        [TearDown]
        public void TearDown()
        {
            _mock = new Mock<IPasswordService>();
        }

        [Test]
        public void CalculateHashPasswordThrowsArgumentNullExceptionTest()
        {
            _mock.Setup(a => a.CalculateHashedPassword(string.Empty, string.Empty))
                .Throws(new ArgumentNullException());

            Assert.Throws<ArgumentNullException>(() =>
            {
                _mock.Object.CalculateHashedPassword(string.Empty, string.Empty);
            });
        }

        [Test]
        public void CalculateHashPasswordTest()
        {
            _mock.Setup(a => a.CalculateHashedPassword(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(It.IsAny<string>());

            Assert.That(_mock.Object.CalculateHashedPassword(It.IsAny<string>(), It.IsAny<string>()), Is.EqualTo(It.IsAny<string>()));
        }
    }
}