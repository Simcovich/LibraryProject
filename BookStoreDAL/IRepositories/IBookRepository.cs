using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book book);

        Task UpdateBookAsync(Book book);

        Task<Book> GetBookByIdAsync(int id);

        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}