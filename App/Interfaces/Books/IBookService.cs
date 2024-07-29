using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Data;


namespace Library.App.Interfaces.Books
{
    public interface IBookService
    {
        object employees { get; }

        IEnumerable<Book> GetAllBooks();
        Book GetById(int Id);
        void AddBook( Book book);
        void UpdateBook(int IdBook, int IdEmployee, Book book);
        void DeleteBook(int IdBook,int IdEmployee);
    }
}