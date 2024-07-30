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
    [Route("api/books/employees/{Id}")]
    public IActionResult CreateBook(int Id, [FromBody] Book book)
    {
        try
        {
            _context.AddBook(Id, book);
            return Ok("Book added successfully.");
        }
        catch (Exception ex)
        {
            // Manejo de errores y retorno de una respuesta adecuada
            Console.WriteLine($"An error occurred while creating the book: {ex.Message}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
}
    }
}