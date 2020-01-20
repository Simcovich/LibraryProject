using BL.API;
using DAL.IRepositories;
using Serilog;

namespace BL.Services
{
    public class SearchService : ServiceBase, ISearchService
    {
        private IAbstractItemRepository _repo;

        public SearchService(ILogger logger, IAbstractItemRepository repo) : base(logger)
        {
            _repo = repo;
        }
    }
}