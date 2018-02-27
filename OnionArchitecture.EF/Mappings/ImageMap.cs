using System.Data.Entity.ModelConfiguration;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.EF.Mappings
{
    public class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            HasKey(t => t.Id);
            Property(t => t.ImageBytes).IsRequired();
            Property(t => t.Name).IsRequired();

            ToTable("Image", "dbo");
        }
    }
}