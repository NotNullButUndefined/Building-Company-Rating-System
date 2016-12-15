using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface IUserService
    {
        bool TryLogin(string email, string password);
    }
}
