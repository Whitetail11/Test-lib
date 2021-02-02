using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.bookService.GetBooks());
        }
        [Route("Take")]
        [HttpPut]
        [Authorize]
        public IActionResult TakeBook(int bookId)
        {
            bookService.TakeBook(bookId);
            return Ok();
        }
        [Route("Return")]
        [HttpPut]
        [Authorize]
        public IActionResult ReturnBook(int bookId)
        {
            bookService.ReturnBook(bookId);
            return Ok();
        }
    }
}
