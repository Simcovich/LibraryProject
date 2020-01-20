using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IGenreRepository
    {
        Task<Genre> AddGenreAsync(Genre genre);

        Task<IEnumerable<Genre>> GetGenresAsync();

        Task UpdateGenreAsync(Genre genre);
    }
}