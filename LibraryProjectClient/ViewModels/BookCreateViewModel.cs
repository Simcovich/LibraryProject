using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProjectClient.ViewModels
{
    public class BookCreateViewModel : ViewModelBase
    {
        public BookCreateViewModel(IBookStoreService service)
        {
            _service = service;
            PrintDate = DateTime.Now;
            Genres = new Genre[3];
            GetGenresAsync();
            GetAuthorsAsync();
            GetPublishersAsync();
            Command = new RelayCommand(AddBook);
        }


        public ObservableCollection<Genre> GenreList { get => genreList; set => Set(ref genreList, value); }
        public ObservableCollection<Author> AuthorList { get => authorList; set => Set(ref authorList, value); }
        public ObservableCollection<Publisher> PublisherList { get => publisherList; set => Set(ref publisherList, value); }
        public RelayCommand Command { get; set; }
        private IBookStoreService _service;
        private ObservableCollection<Genre> genreList;
        private ObservableCollection<Author> authorList;
        private ObservableCollection<Publisher> publisherList;
        private string title;
        private DateTime printDate;
        private Author author;
        private Publisher publisher;
        private string description;
        private string iSBN;
        private int stock;
        private decimal price;
        private Genre[] genres;

        public string Title { get => title; set => Set(ref title, value); }
        public DateTime PrintDate { get => printDate; set => Set(ref printDate, value); }
        public Author Author { get => author; set => Set(ref author, value); }
        public Publisher Publisher { get => publisher; set => Set(ref publisher, value); }
        public string Description { get => description; set => Set(ref description, value); }
        public string ISBN { get => iSBN; set => Set(ref iSBN, value); }
        public int Stock { get => stock; set => Set(ref stock, value); }
        public decimal Price { get => price; set => Set(ref price, value); }
        public Genre[] Genres { get => genres; set => Set(ref genres, value); }
        private async void GetPublishersAsync()
        {
            PublisherList = new ObservableCollection<Publisher>(await _service.GetAllPublishersAsync());
        }

        private async void GetAuthorsAsync()
        {
            AuthorList = new ObservableCollection<Author>(await _service.GetAllAuthorsAsync());
        }

        private async void GetGenresAsync()
        {
            GenreList = new ObservableCollection<Genre>(await _service.GetAllGenresAsync());
        }
        private async void AddBook()
        {
            var itemgenres = Genres
                .Where(g => g != null)
                .Select(g => new AbstractItemGenre() { GenreId = g.Id }).ToList();
            var newBook = new Book() {
                Author = Author,
                Description = Description,
                ISBN = ISBN,
                ItemGenres = itemgenres,
                Price = Price,
                PrintDate = PrintDate,
                Publisher = Publisher,
                Stock = Stock,
                Title = Title
            };

            await _service.AddBookAsync(newBook);

            ResetForm();
        }
        private void ResetForm()
        {
            Title = "";
            PrintDate = DateTime.Now;
            Author = null;
            Publisher = null;
            ISBN = "";
            Description = "";
            Stock = 0;
            Genres = new Genre[3];
            Price = 0.0M;
        }
    }
}
