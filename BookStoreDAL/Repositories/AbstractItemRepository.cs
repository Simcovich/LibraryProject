using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AbstractItemRepository : IAbstractItemRepository
    {
        BookStoreContext _context;
        public AbstractItemRepository(BookStoreContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<AbstractItem>> GetItemsByTitleAsync(string value)
        {
            return Task.Run(() => _context.Items
            .Where(i => i.Title.StartsWith(value))
            .Include(i=>i.Publisher)
            .Include(i=>i.ItemGenres)
            .ThenInclude(ig=>ig.Genre)
            .AsEnumerable());
        }
    }
}