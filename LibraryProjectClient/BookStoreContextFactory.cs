using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace LibraryProjectClient
{
    public class BookStoreContextFactory : IDesignTimeDbContextFactory<BookStoreContext>
    {
        public BookStoreContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            var builder = new DbContextOptionsBuilder<BookStoreContext>();
            builder.UseSqlServer(config.GetConnectionString("SqlConnection"));
            return new BookStoreContext(builder.Options);
        }
    }
}
