using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.API
{
    public interface IBookService
    {
        Task<Book> AddBookAsync(Book book);

        Task<List<Book>> GetAllBooksAsync();

        Task UpdateBookAsync(Book book);
    }
}