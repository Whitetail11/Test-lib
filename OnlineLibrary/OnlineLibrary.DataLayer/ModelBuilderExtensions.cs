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
                    Name = "admin",
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "admin")          
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
