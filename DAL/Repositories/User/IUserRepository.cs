using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmailAndPassword(string email, string password);
        User GetByEmail(string email);
    }
}
