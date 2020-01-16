using DAL.IRepositories;
using Shared.Models;

namespace DAL.Repositories
{
    public class PublisherReposiory : IPublisherRepository
    {
        private BookStoreContext _context;
        public PublisherReposiory(BookStoreContext context)
        {
            _context = context;
        }
        public Publisher AddPublisher(Publisher publisher)
        {
            var publisherEntity = _context.Add(publisher);
            _context.SaveChanges();
            return publisherEntity.Entity;
        }
    }
}