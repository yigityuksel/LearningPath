using System;
using System.Linq;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Services
{
    public class ImageService : IImageService
    {

        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public bool SaveImage(Image image)
        {
            if (!image.ImageBytes.Any())
                throw new BadImageFormatException();

            return _imageRepository.SaveImage(image);
        }

        public Image GetImageById(Guid id)
        {
            var result = _imageRepository.GetImageById(id);

            if (result == null)
                throw new ImageNotFoundException();

            return result;
        }
    }
}