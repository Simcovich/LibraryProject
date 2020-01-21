using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Shared.Models;
using System.Windows.Input;

namespace LibraryProjectClient.ViewModels
{
    public class GenreCreateViewModel : ViewModelBase
    {
        private IGenreService _service;

        public GenreCreateViewModel(IGenreService service)
        {
            _service = service;
            AddGenreCommand = new RelayCommand(AddGenre);
        }

        public ICommand AddGenreCommand { get; set; }
        public string Name { get; set; }

        private async void AddGenre()
        {
            var genre = new Genre() { Name = Name };
            await _service.AddGenreAsync(genre);
            Name = "";
            Messenger.Default.Send<Genre>(genre);
        }
    }
}