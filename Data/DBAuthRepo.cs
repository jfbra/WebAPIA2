using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIA2.Models;

namespace WebAPIA2.Data
{
    public class DBAuthRepo : IAuthRepo
    {
        private readonly WebAPIA2DBContext _dbContext;

        public DBAuthRepo(WebAPIA2DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public bool ValidLogin(string userName, string password)
        {
            User u = _dbContext.Users.FirstOrDefault(e => e.UserName == userName && e.Password == password);
            if (u == null)
                return false;
            else
                return true;
        }
    }
}
