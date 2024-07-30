using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Interfaces.Books;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Books
{
    public class DeleteBookCrontroller : ControllerBase
    {
        private readonly IBookService _context;
        public DeleteBookCrontroller(IBookService context){
            _context = context;
        }

        [HttpDelete]
        [Route("api/book/{IdBook}/employees/{IdEmployee}")]

        public IActionResult DeleteBook(int IdBook, int IdEmployee){
            _context.DeleteBook(IdBook, IdEmployee);
            return Ok();
        }
    }
}