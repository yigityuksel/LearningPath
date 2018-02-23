using System;
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

        private IUserService _userService;
        private Guid _currentUserId;

        [SetUp]
        public void UserServiceTestsSetup()
        {
            _userService = new UserService(new UserRepositoy(new RepositoryContext()), new UserPasswordHistoryService(new PasswordHistoryRepository(new RepositoryContext()), new PasswordService()));
            _currentUserId = Guid.Parse("104FA59B-7913-436D-AB58-9F480751ADAA");
        }

        [Test]
        public void AddUser()
        {

        }

        [Test]
        public void GetUserByUserName()
        {
            Assert.Throws<UserNotFoundException>(() => _userService.GetUserByUserName("test_user_"));
        }

        [Test]
        public void GetUserByUserId()
        {
            Assert.Throws<UserNotFoundException>(() => _userService.GetUserByUserId(Guid.NewGuid()));
        }

    }
}