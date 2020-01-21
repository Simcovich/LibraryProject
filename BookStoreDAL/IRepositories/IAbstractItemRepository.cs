using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IAbstractItemRepository
    {
        Task<IEnumerable<AbstractItem>> GetItemsByTitleAsync(string value);
    }
}