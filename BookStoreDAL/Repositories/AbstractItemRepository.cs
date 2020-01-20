using DAL.IRepositories;
using Shared.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class AbstractItemRepository : IAbstractItemRepository
    {
        public IEnumerable<AbstractItem> GetAllItems()
        {
            throw new System.NotImplementedException();
        }
    }
}