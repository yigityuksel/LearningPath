using System;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Models;

namespace OnionArchitecture.Infra.Repositories
{
    public class UserRepositoy : IUserRepository
    {

        private readonly IOnionArchitectureContext _context;

        public UserRepositoy(IOnionArchitectureContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            try
            {
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
    }
}