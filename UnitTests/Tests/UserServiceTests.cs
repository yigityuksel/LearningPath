using System;
using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Core.Services;

namespace UnitTests.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserService _userService;
        private Mock<IUserRepository> _mockUserRepository;

        [SetUp]
        public void SetUp()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockUserRepository.Reset();
        }

        [Test]
        public void AddUserTest()
        {
            var user = new User();

            _mockUserRepository.Setup(a => a.AddUser(It.IsAny<User>())).Returns(user);

            Assert.Multiple(() =>
            {
                Assert.That(_userService.AddUser(It.IsAny<User>()), Is.EqualTo(user));
            });
        }

        [Test]
        public void GetUserByUserNameThrowsExceptionTest()
        {
            _mockUserRepository.Setup(a => a.GetUserByUserName(It.IsAny<string>())).Returns((User)null);

            Assert.Throws<UserNotFoundException>(() => { _userService.GetUserByUserName(It.IsAny<string>()); });
        }

        [Test]
        public void GetUserByUserNameTest()
        {
            var user = new User();

            _mockUserRepository.Setup(a => a.GetUserByUserName(It.IsAny<string>())).Returns(user);

            Assert.That(_userService.GetUserByUserName(It.IsAny<string>()), Is.EqualTo(user));
        }

        [Test]
        public void GetUserByUserIdThrowsExceptionTest()
        {
            _mockUserRepository.Setup(a => a.GetUserByUserId(It.IsAny<Guid>())).Returns((User)null);

            Assert.Throws<UserNotFoundException>(() => { _userService.GetUserByUserId(It.IsAny<Guid>()); });
        }

        [Test]
        public void GetUserByIdTest()
        {
            var user = new User();

            _mockUserRepository.Setup(a => a.GetUserByUserId(It.IsAny<Guid>())).Returns(user);

            Assert.That(_userService.GetUserByUserId(It.IsAny<Guid>()), Is.EqualTo(user));
        }
    }
}