using System;
using NUnit.Framework;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Infra.MailService;

namespace UnitTests.Tests
{
    [TestFixture]
    public class MailServiceTests
    {
        private IMailService _mailService;
        private string _userMailAddress;
        private string _content;

        [SetUp]
        public void MailServiceTestsSetup()
        {
            _mailService = new MailService();
            _userMailAddress = "yyu@emakina.com";
            _content = "Content";
        }

        [Test]
        public void SendMail()
        {
            var result = _mailService.SendMail(_userMailAddress, _content);
            Assert.IsTrue(result);
        }
    }
}