using System;
using System.Collections.Generic;
using System.Linq;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Models;
using OnionArchitecture.EF.Context;
using OnionArchitecture.EF.Context.Interface;

namespace OnionArchitecture.EF.Repositories
{
    public class PasswordHistoryRepository : IUserPasswordHistoryRepository
    {
        private readonly IRepositoryContext _context;

        public PasswordHistoryRepository(IRepositoryContext context)
        {
            _context = context;
        }

        public UserPasswordHistory SaveUserPreviousPassword(UserPasswordHistory userPassword)
        {
            _context.UserPasswordHistory.Add(userPassword);
            _context.Commit();

            return userPassword;
        }

        public List<UserPasswordHistory> GetUserPreviousPasswordList(Guid userId)
        {
            return _context.UserPasswordHistory
                .Where(a => a.User.Id == userId)
                .OrderBy(a => a.CreationDateTime)
                .Take(5)
                .ToList();
        }
    }
}