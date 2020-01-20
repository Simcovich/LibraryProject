using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IGenreRepository
    {
        Task<Genre> AddGenreAsync(Genre genre);
        Task<IEnumerable<Genre>> GetGenresAsync();
    }
}
