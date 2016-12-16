using BCRS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public User GetByEmailAndPassword(string email, string password)
        {
            using (BuildingServiceContext context = new BuildingServiceContext())
            {
                return context.Set<User>().FirstOrDefault(u => u.Email.Equals(email) &&
                                                               u.Password.Equals(password));
            }
        }

        public User GetByEmail(string email)
        {
            using (BuildingServiceContext context = new BuildingServiceContext())
            {
                return context.Set<User>().FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public void ModifyUserData(User user)
        {
            using (BuildingServiceContext context = new BuildingServiceContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}
