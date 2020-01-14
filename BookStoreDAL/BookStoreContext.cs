using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AbstractItem> Items { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AbstractItemGenre> ItemGenres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Journal> Journals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbstractItemGenre>()
                .HasKey(ig => new { ig.ItemId, ig.GenreId });
            modelBuilder.Entity<AbstractItemGenre>()
                .HasOne(ig => ig.Item)
                .WithMany(i => i.ItemGenres)
                .HasForeignKey(ig => ig.ItemId);
            modelBuilder.Entity<AbstractItemGenre>()
                .HasOne(ig => ig.Genre)
                .WithMany(g => g.ItemGenres)
                .HasForeignKey(ig => ig.GenreId);
        }
    }

}
