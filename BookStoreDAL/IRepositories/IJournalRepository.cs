using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IJournalRepository
    {
        Task<Journal> AddJournalAsync(Journal Journal);
        Task<IEnumerable<Journal>> GetAllJournalsAsync();
    }
}
