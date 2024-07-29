using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Interfaces.Books;
using Library.Models;
using Library.Data;
using Microsoft.EntityFrameworkCore;


namespace Library.App.Services.Books
{
    public class BooksServices : IBookService
    {


        private readonly BaseContext _context;
        public BooksServices(BaseContext context){
            _context = context;
        }

        public object employees => throw new NotImplementedException();

        public void AddBook(Book book)
        {
            // var admin = _context.employees.Find(Id);
            // if (admin != null){
            
            // }
            _context.books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int IdEmployee, int IdBook)
        {
            var admin = _context.employees.Find(IdEmployee);
            if (admin != null){
                var book = _context.books.Find(IdBook);
                if (book != null){
                    book.Status = "inactive";
                }
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.books.Where(b => b.Status == "active").ToList();
        }

        public Book GetById(int Id)
        {

            return _context.books.FirstOrDefault(b => b.Id == Id);;
        }

        public void UpdateBook(int IdBook, int IdEmployee, Book book)
        {
            var admin = _context.employees.FirstOrDefault(b => b.Id == IdEmployee);
            if (admin != null){
                _context.books.Update(book);
                _context.SaveChanges();
            }
        }
    }
}