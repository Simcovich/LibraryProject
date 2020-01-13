using DAL.IRepositories;
using Shared.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    internal class AbstractItemRepostiry : IAbstractItemRepository
    {
        public IEnumerable<AbstractItem> GetAllItems()
        {
            throw new System.NotImplementedException();
        }
    }
}