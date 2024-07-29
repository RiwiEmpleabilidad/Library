using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Interfaces.Books;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Books
{
    public class CreateBookController : ControllerBase
    {
        private readonly IBookService _context;
        public CreateBookController(IBookService context){
            _context = context;
        }

        
        [HttpPost]
        [Route("api/books")]
        public IActionResult CreateBook([FromBody]Book book){
            _context.AddBook(book);
            return Ok();
        }
    }
}