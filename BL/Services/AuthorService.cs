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
    public class AuthorService : ServiceBase, IAuthorService
    {
        private IAuthorRepository _repo;

        public AuthorService(ILogger logger, IAuthorRepository repo) : base(logger)
        {
            _repo = repo;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            try
            {
                return await _repo.AddAuthorAsync(author);
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            try
            {
                var authors = await _repo.GetAuthorsAsync();
                return authors.ToList();
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            try
            {
                await _repo.UpdateAuthorAsync(author);
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }
    }
}