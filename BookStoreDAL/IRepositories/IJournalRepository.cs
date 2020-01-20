using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IJournalRepository
    {
        Task<Journal> AddJournalAsync(Journal Journal);

        Task<IEnumerable<Journal>> GetAllJournalsAsync();

        Task UpdateJournalAsync(Journal journal);
    }
}