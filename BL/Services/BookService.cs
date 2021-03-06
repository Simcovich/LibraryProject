﻿using BL.API;
using DAL.IRepositories;
using Serilog;
using Shared.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BookService : ServiceBase, IBookService
    {
        private IBookRepository _repo;
        private IDiscountService _discountService;

        public BookService(ILogger logger, IBookRepository repo,IDiscountService discountService) : base(logger)
        {
            _repo = repo;
            _discountService = discountService;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            try
            {
                return await _repo.AddBookAsync(book);
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            try
            {
                var books = await _repo.GetAllBooksAsync();
                _discountService.ApplyDiscount(books.Cast<AbstractItem>().ToList());
                return books.ToList();
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }

        public async Task UpdateBookAsync(Book book)
        {
            try
            {
                await _repo.UpdateBookAsync(book);
            }
            catch (DataException e)
            {
                _logger.Error(e.Message);
                throw new DataException(e.Message);
            }
        }
    }
}