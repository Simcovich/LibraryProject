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
        }


        public ICommand JournalsNavigationCommand { get; set; }
        public ICommand BooksNavigationCommand { get; set; }
        public ICommand AuthorNavigationCommand { get; set; }
        public ICommand GenreNavigationCommand { get; set; }
        public ICommand PublisherNavigationCommand { get; set; }
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
    }
}

