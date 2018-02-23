using System;
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
        private ILinkService _linkService;
        private Guid _currentUserId;

        [SetUp]
        public void LinkServiceTestsSetup()
        {
            _linkService = new LinkService(new LinkRepository(new RepositoryContext()));
            _currentUserId = Guid.Parse("104FA59B-7913-436D-AB58-9F480751ADAA");
        }

        [Test]
        public void CreateLink()
        {
            //var result = _linkService.SaveLink(new Link()
            //{
            //    User =_currentUserId,
            //    ExpirationDateTime = DateTime.Now.AddMinutes(60),
            //    Id = Guid.NewGuid(),
            //    Type = LinkType.PasswordReset
            //});
            //Assert.IsNotNull(result);
        }
    }
}