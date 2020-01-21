using BL.API;
using DAL.IRepositories;
using Serilog;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class SearchService : ServiceBase, ISearchService
    {
        private IAbstractItemRepository _repo;
        IDiscountService _discountService;
        public SearchService(ILogger logger, IAbstractItemRepository repo,IDiscountService discountService) : base(logger)
        {
            _repo = repo;
            _discountService = discountService;
        }

        public async Task<List<AbstractItem>> SearchItemsByTitle(string value)
        {
            try
            {
                var items = await _repo.GetItemsByTitleAsync(value);
                var itemList = items.ToList();
                _discountService.ApplyDiscount(itemList);
                return itemList;
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}