using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class BookAuthor
    {
        public int AuthorId { get; set; }
        public Author Authors { get; set; }
        public int BookId { get; set; }
        public Book Books { get; set; }
    }
}
