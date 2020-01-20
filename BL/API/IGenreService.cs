using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.API
{
    public interface IGenreService
    {
        Task<List<Genre>> GetAllGenresAsync();

        Task<Genre> AddGenreAsync(Genre genre);

        Task UpdateGenreAsync(Genre genre);
    }
}