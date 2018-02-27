using System;
using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Core.Services;
using OnionArchitecture.EF.Context;
using OnionArchitecture.EF.Repositories;

namespace UnitTests.Tests
{
    [TestFixture]
    public class ChangeUserPasswordServiceTests
    {
        private IChangeUserPasswordService _passwordService;
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IUserPasswordHistoryService> _mockUserPasswordHistoryService;
        private Mock<IPasswordService> _mockPasswordService;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockPasswordService = new Mock<IPasswordService>();
            _mockUserPasswordHistoryService = new Mock<IUserPasswordHistoryService>();
            _passwordService = new ChangeUserPasswordService(_mockUserRepository.Object, _mockUserPasswordHistoryService.Object, _mockPasswordService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockUserRepository.Reset();
            _mockPasswordService.Reset();
            _mockUserPasswordHistoryService.Reset();
        }

        [Test]
        public void ChangeUserPasswordThrowsPasswordUsedBeforeExceptionTest()
        {
            _mockUserPasswordHistoryService.Setup(a => a.IsPasswordUsedBefore(It.IsAny<Guid>(), It.IsAny<string>())).Returns(true);

            Assert.Throws<PasswordUsedBeforeException>(() => { _passwordService.ChangeUserPassword(new User(), string.Empty); });
        }

        [Test]
        public void ChangeUserPasswordTest()
        {
            var user = new User();

            _mockUserPasswordHistoryService.Setup(a => a.IsPasswordUsedBefore(It.IsAny<Guid>(), It.IsAny<string>())).Returns(false);
            _mockUserRepository.Setup(a => a.UpdateUser(It.IsAny<User>())).Returns(user);

            Assert.That(_passwordService.ChangeUserPassword(user, "1234"), Is.EqualTo(user));
        }

    }
}