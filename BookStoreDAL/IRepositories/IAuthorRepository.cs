using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthorAsync(Author author);

        Task<IEnumerable<Author>> GetAuthorsAsync();

        Task UpdateAuthorAsync(Author author);
    }
}