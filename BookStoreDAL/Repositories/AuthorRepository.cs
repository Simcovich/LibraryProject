using DAL.IRepositories;
using Shared.Models;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private BookStoreContext _context;
        public AuthorRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            var authorEntity = _context.Add(author);
            await _context.SaveChangesAsync();
            return authorEntity.Entity;
        }
    }
}