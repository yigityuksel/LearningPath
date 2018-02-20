using System;
using System.Data.Entity;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Infra.Context
{
    public class OnionArchitectureContext : DbContext, IOnionArchitectureContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<Link> Links { get; set; }

        public OnionArchitectureContext()
            : base("name=OnionArchitectureDB")
        {

        }
        public void Commit()
        {
            SaveChanges();
        }
    }
}