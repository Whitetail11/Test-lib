using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetById(int id);
        ICollection<Book> GetBooks();
        bool TakeBook(int bookId, string userId);
        bool ReturnBook(int bookId, string userId);
    }
}
