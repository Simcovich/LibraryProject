using DAL.IRepositories;
using Shared.Models;

namespace DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private BookStoreContext _context;
        public GenreRepository(BookStoreContext context)
        {
            _context = context;
        }
        public Genre AddGenre(Genre genre)
        {
            var genreEntity = _context.Add(genre);
            _context.SaveChanges();
            return genreEntity.Entity;
        }
    }
}