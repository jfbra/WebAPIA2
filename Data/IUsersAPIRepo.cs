using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIA2.Models;

namespace WebAPIA2.Data
{
    public interface IUsersAPIRepo
    {
        Task<User> AddUserAsync(User user);
        Task<bool> CheckUserAsync(User user);
        Task SaveChangesAsync();
    }
}
