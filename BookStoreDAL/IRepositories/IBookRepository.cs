using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IBookRepository
    {
        Book AddBook(Book book);
        void UpdateBook(Book book);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
    }
}
