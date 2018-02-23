using System;
using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Infra.MailService;

namespace UnitTests.Tests
{
    [TestFixture]
    public class MailServiceTests
    {
        private Mock<IMailService> _mailService;

        [SetUp]
        public void MailServiceTestsSetup()
        {
            _mailService = new Mock<IMailService>();
        }

        [Test]
        public void SendMail()
        {
            _mailService.Setup(a => a.SendMail("test", "test")).Returns(true);
        }
    }
}