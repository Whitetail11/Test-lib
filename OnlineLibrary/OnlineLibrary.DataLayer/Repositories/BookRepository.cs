using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DataLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }
        private bool NotHasBook(int bookId, string userId)
        {
            var res = _dbContext.UsersBooks.AsNoTracking().FirstOrDefault(ub => ub.UserId == userId && ub.BookId == bookId);
            if (res == null)
                return true;
            return false;
        }
        
        public ICollection<Book> GetBooks(BookQueryModel booksParametrs)
        {
            return _dbContext.Books.AsNoTracking()
                .Include(book => book.UsersBooks)
                    .ThenInclude(usersBooks => usersBooks.User)
                .Include(book => book.BookAuthors)
                    .ThenInclude(bookAuthor => bookAuthor.Authors)
                .Skip((booksParametrs.PageNumber - 1) * booksParametrs.Count)
                .Take(booksParametrs.Count)
                .ToList();
        }

        public Book GetById(int id)
        {
            return _dbContext.Books.AsNoTracking()
                .Where(book => book.Id == id)
                .Include(book => book.UsersBooks)
                    .ThenInclude(usersBooks => usersBooks.User)
                .Include(book => book.BookAuthors)
                    .ThenInclude(bookAuthor => bookAuthor.Authors)
                    .FirstOrDefault();
        }

        public bool ReturnBook(int bookId, string userId)
        {
            Book result = _dbContext.Books.Find(bookId);
            UsersBooks usersBooks = new UsersBooks();
            usersBooks.BookId = bookId;
            usersBooks.UserId = userId;
            if(!this.NotHasBook(bookId, userId))
            {
                result.Available++;
                _dbContext.Books.Update(result);
                _dbContext.UsersBooks.Remove(usersBooks);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TakeBook(int bookId, string userId)
        {
            Book result = _dbContext.Books.Find(bookId);
            UsersBooks usersBooks = new UsersBooks();
            usersBooks.BookId = bookId;
            usersBooks.UserId = userId;
            if (result.Amount > 0 && this.NotHasBook(bookId,userId))
            {
                result.Available--;
                _dbContext.Books.Update(result);
                _dbContext.UsersBooks.Add(usersBooks);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetBooksCount()
        {
            return _dbContext.Books.Count();
        }
    }
}
