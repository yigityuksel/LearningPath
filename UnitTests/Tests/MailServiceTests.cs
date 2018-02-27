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
        private Mock<IMailService> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IMailService>();
        }

        [TearDown]
        public void TearDown()
        {
            _mock.Reset();
        }

        [Test]
        public void SendMailTest()
        {
            _mock.Setup(a => a.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            Assert.That(_mock.Object.SendMail(It.IsAny<string>(), It.IsAny<string>()), Is.EqualTo(true));
        }
    }
}