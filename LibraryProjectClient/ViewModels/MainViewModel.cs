using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace LibraryProjectClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IModernNavigationService _modernNavigationService;

        public MainViewModel(IModernNavigationService modernNavigationService)
        {
            _modernNavigationService = modernNavigationService;
            BooksNavigationCommand = new RelayCommand(ShowBooks);
            JournalsNavigationCommand = new RelayCommand(ShowJournals);
            PublisherNavigationCommand = new RelayCommand(ShowPublisher);
            GenreNavigationCommand = new RelayCommand(ShowGenre);
            AuthorNavigationCommand = new RelayCommand(ShowAuthor);
            AddBookNavigationCommand = new RelayCommand(ShowBookCreate);
            AddJournalNavigationCommand = new RelayCommand(ShowJournalCreate);
            AddDiscountNavigationCommand = new RelayCommand(ShowDiscountCreate);
            SearchNavigationCommand = new RelayCommand(ShowSearch);
        }


        public ICommand SearchNavigationCommand { get; set; }
        public ICommand JournalsNavigationCommand { get; set; }
        public ICommand BooksNavigationCommand { get; set; }
        public ICommand AuthorNavigationCommand { get; set; }
        public ICommand GenreNavigationCommand { get; set; }
        public ICommand PublisherNavigationCommand { get; set; }
        public ICommand AddBookNavigationCommand { get; set; }
        public ICommand AddJournalNavigationCommand { get; set; }
        public ICommand AddDiscountNavigationCommand { get; set; }
        private void ShowSearch()
        {
            _modernNavigationService.NavigateTo("SearchPage");
        }

        private void ShowBooks()
        {
            _modernNavigationService.NavigateTo("Books");
        }

        private void ShowJournals()
        {
            _modernNavigationService.NavigateTo("Journals");
        }

        private void ShowAuthor()
        {
            _modernNavigationService.NavigateTo("AddAuthor");
        }

        private void ShowPublisher()
        {
            _modernNavigationService.NavigateTo("AddPublisher");
        }

        private void ShowGenre()
        {
            _modernNavigationService.NavigateTo("AddGenre");
        }

        private void ShowBookCreate()
        {
            _modernNavigationService.NavigateTo("AddBook");
        }

        private void ShowJournalCreate()
        {
            _modernNavigationService.NavigateTo("AddJournal");
        }

        private void ShowDiscountCreate()
        {
            _modernNavigationService.NavigateTo("AddDiscount");
        }
    }
}