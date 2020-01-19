using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthorAsync(Author author);
        Task<IEnumerable<Author>> GetAuthorsAsync();
    }
}
