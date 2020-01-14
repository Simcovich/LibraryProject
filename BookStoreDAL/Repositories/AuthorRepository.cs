using DAL.IRepositories;
using Shared.Models;

namespace DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private BookStoreContext _context;
        public AuthorRepository(BookStoreContext context)
        {
            _context = context;
        }

        public Author AddAuthor(Author author)
        {
            return _context.Add(author).Entity;
        }
    }
}