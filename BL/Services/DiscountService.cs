using BL.API;
using DAL.IRepositories;
using Serilog;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class DiscountService : ServiceBase, IDiscountService
    {
        private IDiscountRepository _repo;

        public DiscountService(ILogger logger, IDiscountRepository repo) : base(logger)
        {
            _repo = repo;
        }

        public async Task AddDiscountAsync(AbstractDiscount discount)
        {
            await _repo.AddDiscountAsync(discount);
        }

        public async Task<List<AbstractDiscount>> GetDiscountsAsync()
        {
            var discounts = await _repo.GetAllDiscountsAsync();
            return discounts.ToList();
        }

        public async Task<List<AbstractDiscount>> GetApplicableDiscountsAsync()
        {
            var discounts = await _repo.GetAllDiscountsAsync();
            return discounts.ToList();
        }

        public async void ApplyDiscount(ICollection<AbstractItem> items)
        {
            var discounts = await GetApplicableDiscountsAsync();
            decimal topDiscount = 0;
            foreach (var item in items)
            {
                foreach (var discount in discounts)
                {
                    if (discount.IsDiscountApplicable(item))
                    {
                        topDiscount = Math.Max(topDiscount, discount.Percent);
                    }
                }
                item.Discount = topDiscount;
                topDiscount = 0;
            }
        }
    }
}