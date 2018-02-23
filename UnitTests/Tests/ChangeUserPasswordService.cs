using System;
using NUnit.Framework;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Services;
using OnionArchitecture.EF.Context;
using OnionArchitecture.EF.Repositories;

namespace UnitTests.Tests
{
    [TestFixture]
    public class ChangeUserPasswordService
    {
        private IChangeUserPasswordService _changeUserPasswordService;
        private IUserService _userService;
        private Guid _currentUserId;

        [SetUp]
        public void UserServiceTestsSetup()
        {
            _changeUserPasswordService = new OnionArchitecture.Core.Services.ChangeUserPasswordService(
                new UserRepositoy(new RepositoryContext()),
                new UserPasswordHistoryService(
                    new PasswordHistoryRepository(
                        new RepositoryContext()),
                    new PasswordService()),
                new PasswordService());

            _userService = new UserService(
                new UserRepositoy(new RepositoryContext()),
                new UserPasswordHistoryService(
                    new PasswordHistoryRepository(
                        new RepositoryContext()),
                    new PasswordService()));

            _currentUserId = Guid.Parse("104FA59B-7913-436D-AB58-9F480751ADAA");
        }

        [Test]
        public void ChangeUserPassword()
        {
            var currentUser = _userService.GetUserByUserId(_currentUserId);

            Assert.Throws<PasswordUsedBeforeException>(() => _changeUserPasswordService.ChangeUserPassword(currentUser, "1234"));
        }

    }
}