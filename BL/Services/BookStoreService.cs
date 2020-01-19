using BL.API;
using DAL.IRepositories;
using Serilog;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BookStoreService : IBookStoreService
    {
        private IBookStoreRepository _repo;
        private ILogger _logger;

        public BookStoreService(IBookStoreRepository repo,ILogger logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public async Task<Author> AddAuthorAsync(Author author)
        {
            var newAuthor = await _repo.GetAuthorRepository.AddAuthorAsync(author);
            return newAuthor;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var newBook = await _repo.GetBookRepository.AddBookAsync(book);
            return newBook;
        }

        public async Task<Journal> AddJournalAsync(Journal journal)
        {
            var newJournal = await _repo.GetJournalRepository.AddJournalAsync(journal);
            return newJournal;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var authors = await _repo.GetAuthorRepository.GetAuthorsAsync();
            return authors.ToList();
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            var genres = await _repo.GetGenreRepository.GetGenresAsync();
            return genres.ToList();
        }

        public async Task<List<Publisher>> GetAllPublishersAsync()
        {
            var publishers = await _repo.GetPublisherReposiory.GetPublishersAsync();
            return publishers.ToList();
        }
    }
}
