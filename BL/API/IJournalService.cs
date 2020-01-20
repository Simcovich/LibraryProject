using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.API
{
    public interface IJournalService
    {
        Task<List<Journal>> GetAllJournalsAsync();

        Task<Journal> AddJournalAsync(Journal journal);

        Task UpdateJournalAsync(Journal journal);
    }
}