using System.Data.Entity.ModelConfiguration;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.EF.Mappings
{
    public class LinkMap : EntityTypeConfiguration<Link>
    {
        public LinkMap()
        {
            HasKey(t => t.Id);
            Property(t => t.UserId).IsRequired();
            Property(t => t.Type).IsRequired();
            Property(t => t.ExpirationDateTime).IsRequired();

            ToTable("Link");
        }
    }
}