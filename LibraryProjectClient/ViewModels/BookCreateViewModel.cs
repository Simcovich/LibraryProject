using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryProjectClient.ViewModels
{
    public class BookCreateViewModel : ViewModelBase
    {
        private IBookService _bookService;
        private IPublisherService _publisherService;
        private IAuthorService _authorService;
        private IGenreService _genreService;
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
        private IModernNavigationService _modernNavigationService;
        private IMessageService _messageService;

        public BookCreateViewModel(IBookService bookService, IPublisherService publisherService, IGenreService genreService, IAuthorService authorService,
            IModernNavigationService modernNavigationService, IMessageService messageService)
        {
            _publisherService = publisherService;
            _bookService = bookService;
            _genreService = genreService;
            _authorService = authorService;
            PrintDate = DateTime.Now;
            Genres = new Genre[3];
            GetGenresAsync();
            GetAuthorsAsync();
            GetPublishersAsync();
            Command = new RelayCommand(AddBook);
            _modernNavigationService = modernNavigationService;
            _messageService = messageService;
            Messenger.Default.Register<Genre>(this, AddGenre);
            Messenger.Default.Register<Publisher>(this, onPublisherAdd);
            Messenger.Default.Register<Author>(this, AddAuthor);
        }

        private void onPublisherAdd(Publisher publisher)
        {
            PublisherList.Add(publisher);
        }

        private void AddGenre(Genre genre)
        {
            GenreList.Add(genre);
        }
        private void AddAuthor(Author author)
        {
            AuthorList.Add(author);
        }

        public ObservableCollection<Genre> GenreList { get => genreList; set => Set(ref genreList, value); }
        public ObservableCollection<Author> AuthorList { get => authorList; set => Set(ref authorList, value); }
        public ObservableCollection<Publisher> PublisherList { get => publisherList; set => Set(ref publisherList, value); }
        public RelayCommand Command { get; set; }

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
            PublisherList = new ObservableCollection<Publisher>(await _publisherService.GetAllPublishersAsync());
        }

        private async void GetAuthorsAsync()
        {
            AuthorList = new ObservableCollection<Author>(await _authorService.GetAllAuthorsAsync());
        }

        private async void GetGenresAsync()
        {
            GenreList = new ObservableCollection<Genre>(await _genreService.GetAllGenresAsync());
        }

        private async void AddBook()
        {
            var itemgenres = Genres
                .Where(g => g != null)
                .Select(g => new AbstractItemGenre() { GenreId = g.Id }).ToList();
            var newBook = new Book()
            {
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
            try
            {
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateObject(newBook, new ValidationContext(newBook), validationResults);
                if (validationResults.Count == 0)
                {
                    await _bookService.AddBookAsync(newBook);
                    Messenger.Default.Send(newBook);
                    ResetForm();
                    _modernNavigationService.NavigateTo("Books");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in validationResults)
                    {
                        sb.Append($"{item.ErrorMessage}\n");
                    }
                    _messageService.ShowMessage(sb.ToString());
                }
            }
            catch (Exception e)
            {
                _messageService.ShowMessage(e.InnerException.Message);
            }
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