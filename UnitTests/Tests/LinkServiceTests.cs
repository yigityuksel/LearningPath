using System;
using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Enums;
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
        private Mock<ILinkService> _linkService;
        private Mock<Link> _link;

        [SetUp]
        public void LinkServiceTestsSetup()
        {
            _linkService = new Mock<ILinkService>();
            _link = new Mock<Link>();
        }

        [Test]
        public void CreateLink()
        {
            _linkService.Setup(a => a.SaveLink(_link.Object)).Returns(_link.Object);
        }
    }
}