using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionArchitecture.Core.Enums;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Infra.Context;
using OnionArchitecture.Infra.Repositories;
using OnionArchitecture.Infra.Services;

namespace UnitTests.Tests
{
    [TestClass]
    public class UserTest
    {

        //needs DI
        private readonly IPasswordService _passwordService = new PasswordService();
        private readonly IUserService _userService = new UserService(new UserRepositoy(new RepositoryContext()), new UserPasswordHistoryService(new PasswordHistoryRepository(new RepositoryContext()), new PasswordService()), new PasswordService());
        private readonly ILinkService _linkService = new LinkService(new LinkRepository(new RepositoryContext()));
        private readonly IMailService _mailService = new MailService();

        [TestMethod]
        public void AddUser()
        {
            const string plainPassword = "1234";
            var salt = Guid.NewGuid().ToString();

            var hashedPassword = _passwordService.CalculateHashedPassword(plainPassword, salt);

            var user = new User()
            {
                Username = "test_user_name",
                Id = Guid.NewGuid(),
                Password = hashedPassword,
                Salt = salt,
                Email = "yyyuksel1992@gmail.com",
                PasswordCreationTime = DateTime.Now
            };

            var result = _userService.AddUser(user);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ChangeUserPassword()
        {
            var currentUserId = Guid.Parse("104FA59B-7913-436D-AB58-9F480751ADAA");
            var currentUser = _userService.GetUserByUserId(currentUserId);
            
            var result = _userService.ChangeUserPassword(currentUserId, "122222");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SendResetLink()
        {
            var currentUserId = Guid.Parse("104FA59B-7913-436D-AB58-9F480751ADAA");
            var currentUser = _userService.GetUserByUserId(currentUserId);

            var result = _linkService.SaveLink(new Link()
            {
                UserId =  currentUserId,
                ExpirationDateTime = DateTime.Now.AddMinutes(60),
                Id = Guid.NewGuid(),
                Type = LinkType.PasswordReset
            });

            var mailResult =_mailService.SendMail(currentUser.Email, "Reset Mail content");

            Assert.IsTrue(mailResult);
            Assert.IsNotNull(result);

        }

    }
}