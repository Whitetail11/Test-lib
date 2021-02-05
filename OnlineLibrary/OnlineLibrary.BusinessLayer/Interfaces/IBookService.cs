using BusinessLayer.DTOs;
using OnlineLibrary.DataLayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBookService
    {
        ICollection<BookDTO> GetBooks(BookQueryModel booksParametrs);
        BookDTO GetById(int id);
        bool TakeBook(int bookId, string userId);
        bool ReturnBook(int bookId, string userId);
        int GetBooksCount();
    }
}
