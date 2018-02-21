using System;
using System.Data.Entity.Migrations;
using System.Linq;
using OnionArchitecture.Core.Exceptions;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Models;
using OnionArchitecture.EF;
using OnionArchitecture.EF.Context;

namespace OnionArchitecture.Infra.Repositories
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
            try
            {

                if (_context.Users.Any(a => a.Username == user.Username))
                    throw new SameUserNameExistException();

                _context.Users.Add(user);
                _context.Commit();

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;

        }

        public User GetUserByUserName(string username)
        {
            try
            {
                return _context.Users.FirstOrDefault(a => a.Username == username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public User GetUserByUserId(Guid userId)
        {
            try
            {
                return _context.Users.Find(userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public User ChangeUserPassword(User user)
        {
            try
            {
                _context.Users.AddOrUpdate(user);
                _context.Commit();

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }
    }
}