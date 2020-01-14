using DAL.IRepositories;
using Shared.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public Book AddBook(Book book)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new System.NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}