using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Краткая история времени",
                    Amount = 4,
                    Available = 4
                },
                new Book
                {
                    Id = 2,
                    Name = "Сияние",
                    Amount = 2,
                    Available = 2
                },
                new Book
                {
                    Id = 3,
                    Name = "Математика",
                    Amount = 3,
                    Available = 3
                }
                );
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "Стивен Кинг"
                },
                new Author
                {
                    Id = 2,
                    Name = "Стивен Хокинг"
                },
                new Author
                {
                    Id = 3,
                    Name = "Вася"
                },
                new Author
                {
                    Id = 4,
                    Name = "Петя"
                }
                );
            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor
                {
                    AuthorId = 1,
                    BookId = 2
                },
                new BookAuthor
                {
                    AuthorId = 2,
                    BookId = 1
                },
                new BookAuthor
                {
                    AuthorId = 3,
                    BookId = 3,
                },
                new BookAuthor
                {
                    AuthorId = 4,
                    BookId = 3
                }
                );
        }
    }
}
