using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Core.Interfaces.Repositories
{
    public interface IOnionArchitectureContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserPassword> UserPasswords { get; set; }
        DbSet<Link> Links { get; set; }
        void Commit();
    }
}