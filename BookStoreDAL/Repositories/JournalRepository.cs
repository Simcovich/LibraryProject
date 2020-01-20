using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class JournalRepository : IJournalRepository
    {
        private BookStoreContext _context;

        public JournalRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<Journal> AddJournalAsync(Journal journal)
        {
            var journalEntity = _context.Add(journal);
            await _context.SaveChangesAsync();
            return journalEntity.Entity;
        }

        public Task<IEnumerable<Journal>> GetAllJournalsAsync()
        {
            var journals = Task.Run(() => _context.Journals.Include(j => j.ItemGenres).ThenInclude(ig => ig.Genre).AsEnumerable());
            return journals;
        }

        public async Task UpdateJournalAsync(Journal journal)
        {
            _context.Journals.Update(journal);
            await _context.SaveChangesAsync();
        }
    }
}