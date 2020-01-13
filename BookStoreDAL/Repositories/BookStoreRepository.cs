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
        public IAbstractItemRepository GetAbstractItemRepository => new AbstractItemRepostiry();
        public IAuthorRepository GetAuthorRepository => new AuthorRepository();
        public IBookRepository GetBookRepository => new BookRepository();
        public IDiscountRepository GetDiscountRepository => new DiscountRepository();
        public IGenreRepository GetGenreRepository => new GenreRepository();
        public IJournalRepository GetJournalRepository =>  new JournalRepository();
        public IPublisherRepository GetPublisherReposiory =>  new PublisherReposiory();
    }
}
