using System;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Services
{
    public interface IImageService
    {
        bool SaveImage(Image image);

        Image GetImageById(Guid id);
    }
}