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
        void TakeBook(int bookId);
        void ReturnBook(int bookId);
    }
}
