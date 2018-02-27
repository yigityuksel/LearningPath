using System;
using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;

namespace UnitTests.Tests
{
    [TestFixture]
    public class UserServiceTests
    {

        private Mock<IUserService> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IUserService>();
        }

        [TearDown]
        public void TearDown()
        {
            _mock.Reset();
        }

        [Test]
        public void AddUserTest()
        {

            _mock.Setup(a => a.AddUser(It.IsAny<User>())).Returns(It.IsAny<User>());

            Assert.Multiple(() =>
            {
                Assert.That(_mock.Object.AddUser(It.IsAny<User>()), Is.EqualTo(It.IsAny<User>()));
            });
        }

        [Test]
        public void GetUserByUserNameThrowsExceptionTest()
        {
            _mock.Setup(a => a.GetUserByUserName(It.IsAny<string>())).Throws(new UserNotFoundException());

            Assert.Throws<UserNotFoundException>(
                () => { _mock.Object.GetUserByUserName(It.IsAny<string>()); });
        }

        [Test]
        public void GetUserByUserNameTest()
        {
            _mock.Setup(a => a.GetUserByUserName(It.IsAny<string>())).Returns(It.IsAny<User>());

            Assert.That(_mock.Object.GetUserByUserName(It.IsAny<string>()), Is.EqualTo(It.IsAny<User>()));
        }

        [Test]
        public void GetUserByUserIdThrowsExceptionTest()
        {
            _mock.Setup(a => a.GetUserByUserId(It.IsAny<Guid>())).Throws(new UserNotFoundException());

            Assert.Throws<UserNotFoundException>(
                () => { _mock.Object.GetUserByUserId(It.IsAny<Guid>()); });
        }

        [Test]
        public void GetUserByIdTest()
        {
            _mock.Setup(a => a.GetUserByUserId(It.IsAny<Guid>())).Returns(It.IsAny<User>());

            Assert.That(_mock.Object.GetUserByUserId(It.IsAny<Guid>()), Is.EqualTo(It.IsAny<User>()));
        }

    }
}