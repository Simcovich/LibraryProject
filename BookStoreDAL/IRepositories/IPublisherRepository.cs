using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IPublisherRepository
    {
        Task<Publisher> AddPublisherAsync(Publisher publisher);

        Task<IEnumerable<Publisher>> GetPublishersAsync();

        Task UpdatePublisherAsync(Publisher publisher);
    }
}