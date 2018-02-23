using System;
using System.Data.Entity.ModelConfiguration;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.EF.Mappings
{
    public class UserPasswordHistoryMap : EntityTypeConfiguration<UserPasswordHistory>
    {
        public UserPasswordHistoryMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Password).IsRequired();
            Property(t => t.Salt).IsRequired();
            Property(t => t.CreationDateTime).IsRequired();

            HasRequired<User>(a => a.User).WithMany(a => a.UserPasswordHistories).HasForeignKey<Guid>(a => a.UserId);

            ToTable("UserPasswordHistory", "dbo");
        }
    }
}