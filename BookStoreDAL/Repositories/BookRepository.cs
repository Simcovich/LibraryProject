using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            var bookEntity = _context.Add(book);
            await _context.SaveChangesAsync();
            return bookEntity.Entity;
        }

        public Task<Book> GetBookByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateBookAsync(Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}