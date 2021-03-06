﻿using DAL.IRepositories;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PublisherReposiory : IPublisherRepository
    {
        private BookStoreContext _context;

        public PublisherReposiory(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<Publisher> AddPublisherAsync(Publisher publisher)
        {
            var publisherEntity = _context.Add(publisher);
            await _context.SaveChangesAsync();
            return publisherEntity.Entity;
        }

        public Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            return Task.Run(() => _context.Publishers.AsEnumerable());
        }

        public async Task UpdatePublisherAsync(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            await _context.SaveChangesAsync();
        }
    }
}