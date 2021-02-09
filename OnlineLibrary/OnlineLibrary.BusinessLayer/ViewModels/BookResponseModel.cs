using BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLibrary.BusinessLayer.ViewModels
{
    public class BookResponseModel
    {
        public ICollection<BookDTO> Books { get; set; }
        public int Count { get; set; }
        public BookResponseModel(ICollection<BookDTO>books, int count)
        {
            this.Books = books;
            this.Count = count;
        }
    }
}
