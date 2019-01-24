﻿using System.Collections.Generic;
using System.Linq;
using SOLID_SRP.Demo.Infrastructure.Helpers;
using SOLID_SRP.Demo.Infrastructure.Models;

namespace SOLID_SRP.Demo.Infrastructure.Service
{
    /// <summary>
    /// Implementation of <see cref="IProfileService"/>
    /// </summary>
    public class ProfileService : IProfileService
    {
        private readonly IDbContext _context;

        public ProfileService(IDbContext context)
        {
            _context = context;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(x => x.Id == userId);
        }

        public IEnumerable<User> GetAdministrators()
        {
            return _context.Users.Where(x => x.IsAdmin);
        }
    }
}