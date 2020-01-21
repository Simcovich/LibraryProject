using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.API
{
    public interface ISearchService
    {
        Task<List<AbstractItem>> SearchItemsByTitle(string value);
    }
}