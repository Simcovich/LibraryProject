using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.API
{
    public interface IAuthorService
    {
        Task<Author> AddAuthorAsync(Author author);

        Task<List<Author>> GetAllAuthorsAsync();

        Task UpdateAuthorAsync(Author author);
    }
}