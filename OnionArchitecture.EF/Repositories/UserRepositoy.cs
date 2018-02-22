using System;
using System.Data.Entity.Migrations;
using System.Linq;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Models;
using OnionArchitecture.EF.Context;
using OnionArchitecture.EF.Context.Interface;

namespace OnionArchitecture.EF.Repositories
{
    public class UserRepositoy : IUserRepository
    {
        private readonly IRepositoryContext _context;

        public UserRepositoy(IRepositoryContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.Commit();

            return user;
        }

        public User GetUserByUserName(string username)
        {
            return _context.Users.FirstOrDefault(a => a.Username == username);
        }

        public User GetUserByUserId(Guid userId)
        {
            return _context.Users.Find(userId);
        }

        public User UpdateUser(User user)
        {
            _context.Users.AddOrUpdate(user);
            _context.Commit();

            return user;
        }
    }
}