using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class UsersBooks
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
