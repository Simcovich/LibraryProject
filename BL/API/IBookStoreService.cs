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
    }
}
