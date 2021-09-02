using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPIA2.Models;

namespace WebAPIA2.Data
{
    public class DBUsersAPIRepo : IUsersAPIRepo
    {
        private readonly WebAPIA2DBContext _dbContext;

        public DBUsersAPIRepo(WebAPIA2DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            ValueTask<EntityEntry<User>> u = _dbContext.Users.AddAsync(user);
            await u;
            await _dbContext.SaveChangesAsync();
            return u.Result.Entity;
        }

        public async Task<bool> CheckUserAsync(User user)
        {
            User u = _dbContext.Users.FirstOrDefault(e => e.UserName == user.UserName);
            if (u == null)
                return true;
            else
                return false;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
