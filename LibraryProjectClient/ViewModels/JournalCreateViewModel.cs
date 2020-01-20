using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace LibraryProjectClient.ViewModels
{
    public class JournalCreateViewModel : ViewModelBase
    {
        private IJournalService _journalService;
        private IPublisherService _publisherService;
        private IGenreService _genreService;
        private ObservableCollection<Genre> genreList;
        private ObservableCollection<Publisher> publisherList;
        private string title;
        private DateTime printDate;
        private int copyNum;
        private Publisher publisher;
        private string description;
        private string iSSN;
        private int stock;
        private decimal price;
        private Genre[] genres;
        private IModernNavigationService _modernNavigationService;
        private IMessageService _messageService;
        public JournalCreateViewModel(IJournalService journalService, IPublisherService publisherService, IGenreService genreService, 
            IModernNavigationService modernNavigationService,IMessageService messageService)
        {
            _journalService = journalService;
            _publisherService = publisherService;
            _genreService = genreService;
            PrintDate = DateTime.Now;
            Genres = new Genre[3];
            GetGenresAsync();
            GetPublishersAsync();
            Command = new RelayCommand(AddJournal);
            _modernNavigationService = modernNavigationService;
            _messageService = messageService;

        }

        public ObservableCollection<Genre> GenreList { get => genreList; set => Set(ref genreList, value); }
        public ObservableCollection<Publisher> PublisherList { get => publisherList; set => Set(ref publisherList, value); }
        public string Title { get => title; set => Set(ref title, value); }
        public DateTime PrintDate { get => printDate; set => Set(ref printDate, value); }
        public int CopyNum { get => copyNum; set => Set(ref copyNum, value); }
        public Publisher Publisher { get => publisher; set => Set(ref publisher, value); }
        public string Description { get => description; set => Set(ref description, value); }
        public string ISSN { get => iSSN; set => Set(ref iSSN, value); }
        public int Stock { get => stock; set => Set(ref stock, value); }
        public decimal Price { get => price; set => Set(ref price, value); }
        public Genre[] Genres { get => genres; set => Set(ref genres, value); }
        public RelayCommand Command { get; set; }

        private async void GetPublishersAsync()
        {
            PublisherList = new ObservableCollection<Publisher>(await _publisherService.GetAllPublishersAsync());
        }

        private async void GetGenresAsync()
        {
            GenreList = new ObservableCollection<Genre>(await _genreService.GetAllGenresAsync());
        }

        private async void AddJournal()
        {
            var itemgenres = Genres
                .Where(g => g != null)
                .Select(g => new AbstractItemGenre() { GenreId = g.Id }).ToList();
            var newJournal = new Journal()
            {
                CopyNum = CopyNum,
                Description = Description,
                ISSN = ISSN,
                ItemGenres = itemgenres,
                Price = Price,
                PrintDate = PrintDate,
                Publisher = Publisher,
                Stock = Stock,
                Title = Title
            };

            try
            {
                await _journalService.AddJournalAsync(newJournal);
                Messenger.Default.Send(newJournal);
                ResetForm();
                _modernNavigationService.NavigateTo("Journals");
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
            CopyNum = 0;
            Publisher = null;
            ISSN = "";
            Description = "";
            Stock = 0;
            Genres = new Genre[3];
            Price = 0.0M;
        }
    }
}