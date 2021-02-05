using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using OnlineLibrary.DataLayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper mapper;
        private readonly IBookRepository bookRepository;

        public BookService(IMapper mapper, IBookRepository bookRepository)
        {
            this.mapper = mapper;
            this.bookRepository = bookRepository;
        }
        public ICollection<BookDTO> GetBooks(BookQueryModel booksParametrs)
        {
            var res = this.bookRepository.GetBooks(booksParametrs);
            return mapper.Map<ICollection<BookDTO>>(res);
        }

        public int GetBooksCount()
        {
            return this.bookRepository.GetBooksCount();
        }

        public BookDTO GetById(int id)
        {
            return mapper.Map<BookDTO>(this.bookRepository.GetById(id));
        }

        public bool ReturnBook(int bookId, string userId)
        {
            return this.bookRepository.ReturnBook(bookId, userId);
        }

        public bool TakeBook(int bookId, string userId)
        {
            return this.bookRepository.TakeBook(bookId, userId);
        }
    }
}
