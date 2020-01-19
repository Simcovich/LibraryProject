﻿using DAL.IRepositories;
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
        public Genre AddGenre(Genre genre)
        {
            var genreEntity = _context.Add(genre);
            _context.SaveChanges();
            return genreEntity.Entity;
        }
        public Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return Task.Run(() => _context.Genres.AsEnumerable());
        }
    }
}