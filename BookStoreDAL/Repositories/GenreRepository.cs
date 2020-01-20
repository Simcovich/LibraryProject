using DAL.IRepositories;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private BookStoreContext _context;

        public GenreRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<Genre> AddGenreAsync(Genre genre)
        {
            var genreEntity = _context.Add(genre);
            await _context.SaveChangesAsync();
            return genreEntity.Entity;
        }

        public Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return Task.Run(() => _context.Genres.AsEnumerable());
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }
    }
}