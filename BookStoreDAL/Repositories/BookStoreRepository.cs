using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookStoreRepository : IBookStoreRepository
    {
        private readonly BookStoreContext _context;
        public BookStoreRepository(BookStoreContext context)
        {
            _context = context;
        }
        public IAbstractItemRepository GetAbstractItemRepository => new AbstractItemRepostiry();
        public IAuthorRepository GetAuthorRepository => new AuthorRepository(_context);
        public IBookRepository GetBookRepository => new BookRepository(_context);
        public IDiscountRepository GetDiscountRepository => new DiscountRepository();
        public IGenreRepository GetGenreRepository => new GenreRepository(_context);
        public IJournalRepository GetJournalRepository =>  new JournalRepository(_context);
        public IPublisherRepository GetPublisherReposiory =>  new PublisherReposiory(_context);
    }
}
