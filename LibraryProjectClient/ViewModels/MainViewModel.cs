using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace LibraryProjectClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IModernNavigationService _modernNavigationService;
        public MainViewModel(IModernNavigationService modernNavigationService)
        {
            _modernNavigationService = modernNavigationService;
            ResourcesCommand = new RelayCommand(ShowBooks);
        }
        public ICommand ResourcesCommand { get; set; }
        private void ShowBooks()
        {
            _modernNavigationService.NavigateTo("Books");
        }
    }
}

