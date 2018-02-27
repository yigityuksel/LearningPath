using System;

namespace OnionArchitecture.Core.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}