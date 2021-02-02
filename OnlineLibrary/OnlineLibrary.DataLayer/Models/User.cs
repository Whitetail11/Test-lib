using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public ICollection<UsersBooks> UsersBooks { get; set; }
    }
}
