using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Available { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<UsersBooks> UsersBooks { get; set; }
    }
}
