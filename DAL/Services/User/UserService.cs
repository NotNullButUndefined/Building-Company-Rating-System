using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public bool TryLogin(string email, string password)
        {
            var user = _userRepo.GetByEmail(email, password);

            return user == null ? false : true;
        }
    }
}
