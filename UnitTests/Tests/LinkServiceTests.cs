using System;
using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Enums;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
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
        private Link _link;
        private ILinkService _linkService;
        private Mock<ILinkRepository> _mockLinkRepository;

        [SetUp]
        public void SetUp()
        {
            _link = new Link() { ExpirationDateTime = DateTime.Now.AddDays(2) };
            _mockLinkRepository = new Mock<ILinkRepository>();
            _linkService = new LinkService(_mockLinkRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockLinkRepository.Reset();
        }

        [Test]
        public void SaveLinkThrowsLinkCreationFailedExceptionTest()
        {
            _mockLinkRepository.Setup(a => a.SaveLink(It.IsAny<Link>())).Returns((Link)null);

            Assert.Throws<LinkCreationFailedException>(() => { _linkService.SaveLink(It.IsAny<Link>()); });
        }

        [Test]
        public void SaveLinkTest()
        {
            _mockLinkRepository.Setup(a => a.SaveLink(It.IsAny<Link>())).Returns(_link);

            Assert.That(_linkService.SaveLink(It.IsAny<Link>()), Is.EqualTo(_link));
        }

        [Test]
        public void GetLinkByIdThrowsLinkExpiredTest()
        {
            _mockLinkRepository.Setup(a => a.GetLinkById(It.IsAny<Guid>())).Throws(new LinkExpiredException());

            Assert.Throws<LinkExpiredException>(() => { _linkService.GetLinkById(It.IsAny<Guid>()); });
        }

        [Test]
        public void GetLinkById()
        {
            _mockLinkRepository.Setup(a => a.GetLinkById(It.IsAny<Guid>())).Returns(_link);

            Assert.That(_linkService.GetLinkById(It.IsAny<Guid>()), Is.EqualTo(_link));
        }

    }
}