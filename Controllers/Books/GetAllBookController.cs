using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Interfaces.Books;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Library.Controllers.Books
{
    public class GetAllBookController : ControllerBase
    {
        private readonly IBookService _context;
        public GetAllBookController(IBookService context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/books")]
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.GetAllBooks();
        }

        [HttpGet]
        [Route("api/books{Id}")]
        public Book GetBookById(int Id)
        {
            return _context.GetById(Id);
        }
    }
}