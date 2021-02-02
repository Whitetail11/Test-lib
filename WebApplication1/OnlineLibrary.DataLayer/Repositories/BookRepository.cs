using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }
        public ICollection<Book> GetBooks()
        {
            return _dbContext.Books
                .Include(book => book.BookAuthors)
                .ThenInclude(bookAuthor => bookAuthor.Authors)
                .ToList();
        }

        public Book GetById(int id)
        {
            return _dbContext.Books.AsNoTracking()
                .Where(book => book.Id == id)
                .Include(book => book.BookAuthors)
                    .ThenInclude(bookAuthor => bookAuthor.Authors)
                    .FirstOrDefault();
        }

        public void ReturnBook(int bookId)
        {
            Book result = _dbContext.Books.Find(bookId);
            result.Available++;
            _dbContext.Books.Update(result);
            _dbContext.SaveChanges();
        }

        public void TakeBook(int bookId)
        {
            Book result = _dbContext.Books.Find(bookId);
            if(result.Amount > 0)
            {
                result.Available--;
                _dbContext.Books.Update(result);
                _dbContext.SaveChanges();
            }
            else
            {

            }
        }
    }
}
