using BL.API;
using DAL.IRepositories;
using Serilog;
using Shared.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class JournalService : ServiceBase, IJournalService
    {
        private IJournalRepository _repo;
        private IDiscountService _discountService;

        public JournalService(ILogger logger, IJournalRepository repo, IDiscountService discountService) : base(logger)
        {
            _discountService = discountService;
            _repo = repo;
        }

        public async Task<Journal> AddJournalAsync(Journal journal)
        {
            try
            {
                return await _repo.AddJournalAsync(journal);
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }

        public async Task<List<Journal>> GetAllJournalsAsync()
        {
            try
            {
                var journals = await _repo.GetAllJournalsAsync();
                _discountService.ApplyDiscount(journals.Cast<AbstractItem>().ToList());
                return journals.ToList();
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }

        public async Task UpdateJournalAsync(Journal journal)
        {
            try
            {
                await _repo.UpdateJournalAsync(journal);
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }
    }
}