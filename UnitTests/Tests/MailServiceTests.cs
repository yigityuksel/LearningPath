using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Infra.MailService;

namespace UnitTests.Tests
{
    [TestFixture]
    public class MailServiceTests
    {
        private MailService _mailService;

        [SetUp]
        public void SetUp()
        {
            _mailService = new MailService();
        }

        [Test]
        public void SendMailTest()
        {
            Assert.That(_mailService.SendMail(It.IsAny<string>(), It.IsAny<string>()), Is.EqualTo(true));
        }
    }
}