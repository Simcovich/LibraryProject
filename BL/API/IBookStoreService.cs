using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.API
{
    public interface IBookStoreService
    {
        Task<Book> AddBookAsync(Book book);
        Task<Author> AddAuthorAsync(Author author);
        Task<Journal> AddJournalAsync(Journal journal);
        Task<List<Genre>> GetAllGenresAsync();
        Task<List<Author>> GetAllAuthorsAsync();
        Task<List<Publisher>> GetAllPublishersAsync();
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Journal>> GetAllJournalsAsync();
        Task<Genre> AddGenreAsync(Genre genre);
        Task<Publisher> AddPublisherAsync(Publisher publisher);
    }
}
