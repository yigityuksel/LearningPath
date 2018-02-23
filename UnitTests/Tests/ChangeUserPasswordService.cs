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
        private Mock<IChangeUserPasswordService> _changeUserPasswordService;
        private Mock<User> _user;
        private Guid _currentUserId;

        [SetUp]
        public void UserServiceTestsSetup()
        {
            _changeUserPasswordService = new Mock<IChangeUserPasswordService>();
            _user = new Mock<User>();
            _currentUserId = Guid.Parse("104FA59B-7913-436D-AB58-9F480751ADAA");
        }

        [Test]
        public void ChangeUserPassword()
        {
            _changeUserPasswordService
                .Setup(a => a.ChangeUserPassword(_user.Object, "test_password"))
                .Throws<PasswordUsedBeforeException>();
        }

    }
}