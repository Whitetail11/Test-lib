using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
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
                },
                new Book
                {
                    Id = 4,
                    Name = "Математика4",
                    Amount = 5,
                    Available = 5
                },
                new Book
                {
                    Id = 5,
                    Name = "42Математика",
                    Amount = 3,
                    Available = 3
                },
                new Book
                {
                    Id = 6,
                    Name = "99Математика",
                    Amount = 1,
                    Available = 1
                },
                new Book
                {
                    Id = 7,
                    Name = "Математика",
                    Amount = 8,
                    Available = 8
                },
                new Book
                {
                    Id = 8,
                    Name = "1Математика",
                    Amount = 2,
                    Available = 2
                },
                new Book
                {
                    Id = 9,
                    Name = "22Сияние",
                    Amount = 5,
                    Available = 5
                },
                new Book
                {
                    Id = 10,
                    Name = "55Сияние",
                    Amount = 5,
                    Available = 5
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
                },
                new BookAuthor
                {
                    AuthorId = 1,
                    BookId = 4
                },
                new BookAuthor
                {
                    AuthorId = 1,
                    BookId = 5
                },
                new BookAuthor
                {
                    AuthorId = 1,
                    BookId = 6
                },
                new BookAuthor
                {
                    AuthorId = 1,
                    BookId = 7
                },
                new BookAuthor
                {
                    AuthorId = 1,
                    BookId = 8
                },
                new BookAuthor
                {
                    AuthorId = 1,
                    BookId = 9
                },
                new BookAuthor
                {
                    AuthorId = 1,
                    BookId = 10
                }
                );
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
                );
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "a18be9c0-aa61-4af8-bd17-00bd9344e277",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin12345")          
                }
                );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                UserId = "a18be9c0-aa61-4af8-bd17-00bd9344e277"
            }
                );

        }
    }
}
