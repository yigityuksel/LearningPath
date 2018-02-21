using System.Data.Entity;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.EF.Context
{
    public interface IRepositoryContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserPasswordHistory> UserPasswordHistory { get; set; }
        DbSet<Link> Links { get; set; }
        void Commit();
    }
}