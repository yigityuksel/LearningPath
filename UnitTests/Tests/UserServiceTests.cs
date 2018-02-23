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
    public class UserServiceTests
    {

        private Mock<IUserService> _userService;
        private Mock<User> _user;

        [SetUp]
        public void UserServiceTestsSetup()
        {
            _userService = new Mock<IUserService>();
            _user = new Mock<User>();
        }

        [Test]
        public void AddUser()
        {
            _userService.Setup(a => a.AddUser(_user.Object)).Returns(_user.Object);
        }

        [Test]
        public void GetUserByUserName()
        {
            _userService.Setup(a => a.GetUserByUserName("test_user_")).Throws<UserNotFoundException>();
        }

        [Test]
        public void GetUserByUserId()
        {
            _userService.Setup(a => a.GetUserByUserId(Guid.NewGuid())).Throws<UserNotFoundException>();
        }

    }
}