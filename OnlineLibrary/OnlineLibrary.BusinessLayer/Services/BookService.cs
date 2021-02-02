using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
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
        public ICollection<BookDTO> GetBooks()
        {
            return mapper.Map<ICollection<BookDTO>>(this.bookRepository.GetBooks());
        }

        public BookDTO GetById(int id)
        {
            return mapper.Map<BookDTO>(this.bookRepository.GetById(id));
        }

        public void ReturnBook(int bookId)
        {
            this.bookRepository.ReturnBook(bookId);
        }

        public void TakeBook(int bookId)
        {
            this.bookRepository.TakeBook(bookId);
        }
    }
}
