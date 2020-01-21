using DAL.IRepositories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private BookStoreContext _context;

        public DiscountRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task AddDiscountAsync(AbstractDiscount discount)
        {
            _context.Add(discount);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<AbstractDiscount>> GetAllDiscountsAsync()
        {
            var discounts = Task.Run(() => _context.Discounts.AsEnumerable());
            return discounts;
        }

        public Task<IEnumerable<AbstractDiscount>> GetAllApplicableDiscountsAsync()
        {
            var discounts = Task.Run(() => _context.Discounts.Where(d => d.EndDate.CompareTo(DateTime.Now) <= 0 &&
            d.StartDate.CompareTo(DateTime.Now) >= 0).AsEnumerable());
            return discounts;
        }
    }
}