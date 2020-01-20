using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.API
{
    public interface IPublisherService
    {
        Task<Publisher> AddPublisherAsync(Publisher publisher);

        Task<List<Publisher>> GetAllPublishersAsync();

        Task UpdatePublisherAsync(Publisher publisher);
    }
}