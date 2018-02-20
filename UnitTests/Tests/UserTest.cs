using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Infra.Enums;
using OnionArchitecture.Infra.Services;
using UnitTests.Ninject;

namespace UnitTests.Tests
{
    [TestClass]
    public class UserTest
    {
        private readonly IUserService _userService;

        public UserTest()
        {
            IKernel kernel = new StandardKernel(new Bindings());
            _userService = kernel.Get<UserService>();
        }

        [TestMethod]
        public void AddUser()
        {
            var userId = Guid.NewGuid();

            var result = _userService.AddUser(new User()
            {
                Email = "yyyuksel_1992@gmail.com",
                Id = userId,
                Username = "yigit2",
                UserPassword = new List<UserPassword>()
                {
                    new UserPassword()
                    {
                        CreationDate = DateTime.Now,
                        Id = Guid.NewGuid(),
                        Password = "123213",
                        UserId = userId,
                        Status = (short)PasswordStatus.Enabled
                    }
                }
            });

            Assert.IsNotNull(result);

        }

    }
}