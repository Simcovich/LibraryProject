using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LibraryProjectClient.ViewModels
{
    public class DiscountCreateViewModel : ViewModelBase
    {
        private IDiscountService _service;
        private IGenreService _genreService;
        private IAuthorService _authorService;
        private IPublisherService _publisherService;
        private ObservableCollection<Genre> genres;
        private ObservableCollection<Publisher> publishers;
        private ObservableCollection<Author> authors;

        public DiscountCreateViewModel(IDiscountService service, IAuthorService authorService,
         IGenreService genreService, IPublisherService publisherService)
        {
            _service = service;
            AddDiscount = new RelayCommand(ApplyDiscount);
            _genreService = genreService;
            _authorService = authorService;
            _publisherService = publisherService;
            GetAuthors();
            GetGenres();
            GetPublishers();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            PublishedDate = DateTime.Now;
            Messenger.Default.Register<Genre>(this, AddGenre);
            Messenger.Default.Register<Publisher>(this, onPublisherAdd);
            Messenger.Default.Register<Author>(this, AddAuthor);
        }
        private void onPublisherAdd(Publisher publisher)
        {
            Publishers.Add(publisher);
        }

        private void AddGenre(Genre genre)
        {
            Genres.Add(genre);
        }
        private void AddAuthor(Author author)
        {
            Authors.Add(author);
        }
        private async void GetAuthors()
        {
            Authors = new ObservableCollection<Author>(await _authorService.GetAllAuthorsAsync());
        }
        private async void GetGenres()
        {
            Genres = new ObservableCollection<Genre>(await _genreService.GetAllGenresAsync());
        }
        private async void GetPublishers()
        {
            Publishers = new ObservableCollection<Publisher>(await _publisherService.GetAllPublishersAsync());
        }

        public Author Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public Publisher Publisher { get; set; }
        public Genre Genre { get; set; }
        public ObservableCollection<Author> Authors { get => authors; set => Set(ref authors, value); }
        public ObservableCollection<Publisher> Publishers { get => publishers; set => Set(ref publishers, value); }
        public ObservableCollection<Genre> Genres { get => genres; set => Set(ref genres, value); }
        public bool AuthorChecked { get; set; }
        public bool DateChecked { get; set; }
        public bool PublisherCheck { get; set; }
        public bool GenreCheck { get; set; }
        public ICommand AddDiscount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Percent { get; set; }

        private async void ApplyDiscount()
        {
            AbstractDiscount discount = null;
            if (AuthorChecked)
            {
                discount = CreateAuthorDiscount();
            }
            else if (GenreCheck)
            {
                discount = CreateGenreDiscount();
            }
            else if (PublisherCheck)
            {
                discount = CreatePublisherDiscount();
            }
            else if (DateChecked)
            {
                discount = CreatePublishDateDiscount();
            }
            if (discount != null)
            {
                await _service.AddDiscountAsync(discount);
            }
        }

        private AbstractDiscount CreatePublisherDiscount()
        {
            return new DiscountByPublisher(Publisher.Id, StartDate, EndDate, Percent);
        }

        private AbstractDiscount CreateAuthorDiscount()
        {
            return new DiscountByAuthor(Author.Id, StartDate, EndDate, Percent);
        }

        private AbstractDiscount CreateGenreDiscount()
        {
            return new DiscountByGenre(Genre.Id, StartDate, EndDate, Percent);
        }

        private AbstractDiscount CreatePublishDateDiscount()
        {
            return new DiscountByPublishDate(PublishedDate, StartDate, EndDate, Percent);
        }
    }
}