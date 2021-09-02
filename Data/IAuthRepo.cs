using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIA2.Data
{
    public interface IAuthRepo
    {
        public bool ValidLogin(string userName, string password);
    }
}
