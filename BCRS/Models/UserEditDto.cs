using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCRS.Models
{
    public class UserEditDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}