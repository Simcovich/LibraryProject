using DAL.IRepositories;
using Shared.Models;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class JournalRepository : IJournalRepository
    {
        BookStoreContext _context;
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
    }
}