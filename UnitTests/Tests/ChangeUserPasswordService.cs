using System;
using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Core.Services;
using OnionArchitecture.EF.Context;
using OnionArchitecture.EF.Repositories;

namespace UnitTests.Tests
{
    [TestFixture]
    public class ChangeUserPasswordService
    {
        private Mock<IChangeUserPasswordService> _mock;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IChangeUserPasswordService>();

        }

        [TearDown]
        public void TearDown()
        {
            _mock.Reset();
        }

        [Test]
        public void ChangeUserPasswordThrowsPasswordUsedBeforeExceptionTest()
        {
            _mock.Setup(a => a.ChangeUserPassword(It.IsAny<User>(), It.IsAny<string>())).Throws(new PasswordUsedBeforeException());

            Assert.Throws<PasswordUsedBeforeException>(() =>
            {
                _mock.Object.ChangeUserPassword(It.IsAny<User>(), It.IsAny<string>());
            });
        }

        [Test]
        public void ChangeUserPasswordTest()
        {
            _mock.Setup(a => a.ChangeUserPassword(It.IsAny<User>(), It.IsAny<string>())).Returns(It.IsAny<User>());

            Assert.That(_mock.Object.ChangeUserPassword(It.IsAny<User>(), It.IsAny<string>()), Is.EqualTo(It.IsAny<User>()));
        }

    }
}