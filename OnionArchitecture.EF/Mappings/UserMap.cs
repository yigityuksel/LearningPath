using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.EF.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).IsRequired();
            Property(t => t.Username).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.Password).IsRequired();
            Property(t => t.Salt).IsRequired();
            Property(t => t.PasswordCreationTime).IsRequired();


            ToTable("User", "dbo");
        }
    }
}