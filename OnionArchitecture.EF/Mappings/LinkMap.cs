using System;
using System.Data.Entity.ModelConfiguration;
using System.Security.Cryptography.X509Certificates;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.EF.Mappings
{
    public class LinkMap : EntityTypeConfiguration<Link>
    {
        public LinkMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Type).IsRequired();
            Property(t => t.ExpirationDateTime).IsRequired();

            HasRequired<User>(a => a.User).WithMany(a => a.Links).HasForeignKey<Guid>(a => a.UserId);

            ToTable("Link","dbo");
        }
    }
}