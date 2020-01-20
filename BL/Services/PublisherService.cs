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
    public class PublisherService : ServiceBase, IPublisherService
    {
        private IPublisherRepository _repo;

        public PublisherService(ILogger logger, IPublisherRepository repo) : base(logger)
        {
            _repo = repo;
        }

        public async Task<Publisher> AddPublisherAsync(Publisher publisher)
        {
            try
            {
                return await _repo.AddPublisherAsync(publisher);
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }

        public async Task<List<Publisher>> GetAllPublishersAsync()
        {
            try
            {
                var publishers = await _repo.GetPublishersAsync();
                return publishers.ToList();
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }

        public async Task UpdatePublisherAsync(Publisher publisher)
        {
            try
            {
                await _repo.UpdatePublisherAsync(publisher);
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }
    }
}