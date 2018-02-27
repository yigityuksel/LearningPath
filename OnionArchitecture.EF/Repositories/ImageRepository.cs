using System;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Models;
using OnionArchitecture.EF.Context.Interface;

namespace OnionArchitecture.EF.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IRepositoryContext _context;

        public ImageRepository(IRepositoryContext context)
        {
            _context = context;
        }

        public bool SaveImage(Image image)
        {
            _context.Images.Add(image);
            _context.Commit();

            return true;
        }

        public Image GetImageById(Guid id)
        {
            return _context.Images.Find(id);
        }
    }
}