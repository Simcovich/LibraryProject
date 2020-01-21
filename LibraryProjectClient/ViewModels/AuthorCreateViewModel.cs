using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Shared.Models;
using System.Windows.Input;

namespace LibraryProjectClient.ViewModels
{
    public class AuthorCreateViewModel : ViewModelBase
    {
        private IAuthorService _service;

        public AuthorCreateViewModel(IAuthorService service)
        {
            _service = service;
            AddAuthorCommand = new RelayCommand(AddAuthor);
        }

        public ICommand AddAuthorCommand { get; set; }
        public string Name { get; set; }
        public string PenName { get; set; }

        private async void AddAuthor()
        {
            var author = new Author() { Name = Name, PenName = PenName };
            await _service.AddAuthorAsync(author);
            Name = "";
            Messenger.Default.Send<Author>(author);
        }
    }
}