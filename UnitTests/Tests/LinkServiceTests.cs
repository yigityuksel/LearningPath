using System;
using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Enums;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Core.Services;
using OnionArchitecture.EF.Context;
using OnionArchitecture.EF.Repositories;

namespace UnitTests.Tests
{
    [TestFixture]
    public class LinkServiceTests
    {
        private Mock<ILinkService> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ILinkService>();
        }

        [TearDown]
        public void TearDown()
        {
            _mock.Reset();
        }

        [Test]
        public void SaveLinkTest()
        {
            _mock.Setup(a => a.SaveLink(It.IsAny<Link>())).Returns(It.IsAny<Link>());

            Assert.That(_mock.Object.SaveLink(It.IsAny<Link>()), Is.EqualTo(It.IsAny<Link>()));
        }

        [Test]
        public void GetLinkByIdThrowsLinkExpiredTest()
        {
            _mock.Setup(a => a.GetLinkById(It.IsAny<Guid>())).Throws(new LinkExpiredException());

            Assert.Throws<LinkExpiredException>(() => { _mock.Object.GetLinkById(It.IsAny<Guid>()); });
        }

        [Test]
        public void GetLinkById()
        {
            _mock.Setup(a => a.GetLinkById(It.IsAny<Guid>())).Returns(It.IsAny<Link>());

            Assert.That(_mock.Object.GetLinkById(It.IsAny<Guid>()), Is.EqualTo(It.IsAny<Link>()));
        }

    }
}