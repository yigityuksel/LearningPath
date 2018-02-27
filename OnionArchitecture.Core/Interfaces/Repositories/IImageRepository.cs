using System;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Repositories
{
    public interface IImageRepository
    {
        bool SaveImage(Image image);

        Image GetImageById(Guid id);
    }
}