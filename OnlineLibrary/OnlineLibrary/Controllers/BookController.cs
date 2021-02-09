using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BusinessLayer.ViewModels;
using OnlineLibrary.DataLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(this.bookService.GetById(id));
        }
        [Route("Get")]
        [HttpPost]
        public IActionResult GetPage(BookQueryModel bookQueryModel)
        {
            return Ok(new BookResponseModel(this.bookService.GetBooks(bookQueryModel), this.bookService.GetBooksCount()));
        }
        [Route("Take")]
        [Authorize]
        [HttpPut]
        public IActionResult TakeBook(int bookId, string userId)
        {
            if (bookService.TakeBook(bookId, userId))
                return Ok();
            else
                return BadRequest("Book is not available");
        }
        [Route("Return")]
        [Authorize]
        [HttpPut]
        public IActionResult ReturnBook(int bookId, string userId)
        {
            if (bookService.ReturnBook(bookId, userId))
                return Ok();
            else
                return BadRequest("You have no this book");
        }
        [HttpGet]
        [Route("Books")]
        public IActionResult GetUserBooks(string id)
        {
            var user = bookService.GetUserBooks(id);
            return Ok(user.Books);
        }
    }
}
