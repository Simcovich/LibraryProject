using Shared.Models;
using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IAbstractItemRepository
    {
        IEnumerable<AbstractItem> GetAllItems();
    }
}