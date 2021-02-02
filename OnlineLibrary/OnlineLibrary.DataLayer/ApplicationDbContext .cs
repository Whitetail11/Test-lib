using DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> GetBookAuthors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.AuthorId, ba.BookId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Books)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Authors)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            modelBuilder.Entity<UsersBooks>()
                .HasKey(ub => new { ub.UserId, ub.BookId });

            modelBuilder.Seed();
            //modelBuilder.Entity<UsersBooks>()
            //    .HasOne(ba => ba.User)
            //    .WithMany(b => b.UsersBooks)
            //    .HasForeignKey(ba => ba.BookId);

            //modelBuilder.Entity<UsersBooks>()
            //    .HasOne(ba => ba.Book)
            //    .WithMany(a => a.UsersBooks)
            //    .HasForeignKey(ba => ba.UserId);
        }
    }
}
