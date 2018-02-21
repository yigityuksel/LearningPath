using System.Data.Entity.ModelConfiguration;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.EF.Mappings
{
    public class UserPasswordHistoryMap : EntityTypeConfiguration<UserPasswordHistory>
    {
        public UserPasswordHistoryMap()
        {
            HasKey(t => t.Id);
            HasKey(t => t.UserId);
            Property(t => t.Password).IsRequired();
            Property(t => t.Salt).IsRequired();
            Property(t => t.CreationDateTime).IsRequired();

            ToTable("UserPasswordHistory");
        }
    }
}