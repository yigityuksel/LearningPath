using System;
using System.Collections.Generic;
using System.Linq;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Core.Models;
using OnionArchitecture.EF.Context;

namespace OnionArchitecture.Infra.Repositories
{
    public class PasswordHistoryRepository : IUserPasswordHistoryRepository
    {
        private readonly IRepositoryContext _context;

        public PasswordHistoryRepository(IRepositoryContext context)
        {
            _context = context;
        }

        public bool SaveUserPreviousPassword(UserPasswordHistory userPassword)
        {
            try
            {
                _context.UserPasswordHistory.Add(userPassword);
                _context.Commit();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public List<UserPasswordHistory> GetUserPreviousPasswordList(Guid userId)
        {
            try
            {
                return _context.UserPasswordHistory
                    .Where(a => a.UserId == userId)
                    .OrderBy(a => a.CreationDateTime)
                    .Take(5)
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

    }
}