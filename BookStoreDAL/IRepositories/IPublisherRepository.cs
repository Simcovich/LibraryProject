using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IPublisherRepository
    {
        Publisher AddPublisher(Publisher publisher);
        Task<IEnumerable<Publisher>> GetPublishersAsync();
    }
}
