using System;
using Moq;
using NUnit.Framework;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Core.Services;

namespace UnitTests.Tests
{
    [TestFixture]
    public class ImageServiceTests
    {
        private ImageService _imageService;
        private Mock<IImageRepository> _mockImageRepository;

        [SetUp]
        public void Setup()
        {
            _mockImageRepository = new Mock<IImageRepository>();
            _imageService = new ImageService(_mockImageRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockImageRepository.Reset();
        }

        [Test]
        public void SaveImageThrowsBadFormatExceptionTest()
        {
            _mockImageRepository.Setup(a => a.SaveImage(It.IsAny<Image>())).Throws(new BadImageFormatException());

            Assert.Throws<BadImageFormatException>(() => { _imageService.SaveImage(new Image() { ImageBytes = new byte[0] }); });
        }

        [Test]
        public void SaveImageTest()
        {
            _mockImageRepository.Setup(a => a.SaveImage(It.IsAny<Image>())).Returns(true);

            Assert.That(_imageService.SaveImage(new Image() { ImageBytes = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } }), Is.EqualTo(true));
        }

        [Test]
        public void GetImageByIdThrowsImageNotFoundExceptionTest()
        {
            _mockImageRepository.Setup(a => a.GetImageById(It.IsAny<Guid>())).Throws(new ImageNotFoundException());

            Assert.Throws<ImageNotFoundException>(() => { _imageService.GetImageById(It.IsAny<Guid>()); });
        }

        [Test]
        public void GetImageByIdTest()
        {
            var image = new Image();

            _mockImageRepository.Setup(a => a.GetImageById(It.IsAny<Guid>())).Returns(image);

            Assert.That(_mockImageRepository.Object.GetImageById(It.IsAny<Guid>()), Is.EqualTo(image));
        }
    }
}