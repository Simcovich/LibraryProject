using BL.API;
using DAL.IRepositories;
using Serilog;
using Shared.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class GenreService : ServiceBase, IGenreService
    {
        private IGenreRepository _repo;

        public GenreService(ILogger logger, IGenreRepository repo) : base(logger)
        {
            _repo = repo;
        }

        public async Task<Genre> AddGenreAsync(Genre genre)
        {
            try
            {
                return await _repo.AddGenreAsync(genre);
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            try
            {
                var genres = await _repo.GetGenresAsync();
                return genres.ToList();
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            try
            {
                await _repo.UpdateGenreAsync(genre);
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }
    }
}