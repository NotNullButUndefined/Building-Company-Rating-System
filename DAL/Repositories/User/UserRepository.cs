using BCRS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public User GetByEmail(string email)
        {
            using (BuildingServiceContext context = new BuildingServiceContext())
            {
                return context.Set<User>().FirstOrDefault(u => u.Email.Equals(email));
            }
        }
    }
}
