using System.Data.Entity;
using OnionArchitecture.Core.Models;
using OnionArchitecture.EF.Context.Interface;
using OnionArchitecture.EF.Mappings;

namespace OnionArchitecture.EF.Context
{
    public class RepositoryContext : DbContext, IRepositoryContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPasswordHistory> UserPasswordHistory { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Image> Images { get; set; }

        public RepositoryContext() : base("name=OnionArchitectureDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<RepositoryContext>());
        }

        public void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserPasswordHistoryMap());
            modelBuilder.Configurations.Add(new LinkMap());
            modelBuilder.Configurations.Add(new ImageMap());
        }
    }
}